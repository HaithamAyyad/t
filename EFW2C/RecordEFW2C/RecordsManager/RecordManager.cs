using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Records;

namespace EFW2C.Manager
{
    public class RecordManager
    {
        private bool _reSubmitted;
        private bool _unemployment;

        public bool IsTIB { get; set; }

        private List<RecordBase> _records;

        public List<RecordBase> Records { get { return _records; } }

        public RecordManager()
        {
            _records = new List<RecordBase>();

            WageTaxHelper.CreateWageTaxTabel();
        }

        public void write()
        {
            foreach (var record in _records)
                record.Write();
        }

        public bool Verify()
        {
            if (!IsFeildsBelongToClass())
                return true;

            foreach (var record in _records)
            {
                if (!record.Verify())
                    return false;
            }

            if(GetRecordsCount(RecordNameEnum.Rcw) > Constants.MaxRcwRecordsNumber)
                throw new Exception($"Rcw records should not exceed {Constants.MaxRcwRecordsNumber}");

            if(GetRecordsCount(RecordNameEnum.Rce) > Constants.MaxRceRecordsNumber)
                throw new Exception($"Rce records should not exceed {Constants.MaxRceRecordsNumber}");

            return true;
        }

        public int GetRecordsCount(RecordNameEnum recordName)
        {
            return _records.Count(item => item.RecordName == recordName.ToString());
        }

        public RecordManager Clone()
        {
            var manager = new RecordManager()
            {
                _reSubmitted = _reSubmitted,
                _unemployment = _unemployment,
                IsTIB = IsTIB,
            };

            foreach (var record in _records)
                manager.AddRecord(record.Clone(manager));

            return manager;
        }

        private bool IsFeildsBelongToClass()
        {
            foreach (var record in _records)
            {
                if (!record.IsFeildsBelongToClass(record.Fields))
                    return false;
            }

            return true;
        }

        public void AddRecord(RecordBase record)
        {
            _records.Add(record);
        }

        public void SetSubmitter(bool value)
        {
            _reSubmitted = value;
        }

        public void SetUnEmployment(bool value)
        {
            _unemployment = value;
        }

        public bool IsSubmitter()
        {
            return _reSubmitted;
        }

        public bool IsUnEmployment()
        {
            return _unemployment;
        }
        
        public RecordBase GetPrecedRecord(RecordBase sourceRecord, string recordName)
        {
            var pos = _records.Select((record, index) => new { Record = record, Index = index })
                              .FirstOrDefault(item => item.Record.RecordName == sourceRecord.RecordName)?.Index ?? -1;

            for (var i = pos - 1; i >= 0; i--)
            {
                if (_records[i].RecordName == recordName)
                {
                    return _records[i];
                }
            }

            return null;

        }
        public List<RecordBase> GetRecordsBetween(RecordBase first, RecordBase second, string recordName)
        {
            if (first == null || second == null)
            {
                return null;
            }

            int firstIndex = _records.IndexOf(first);
            int secondIndex = _records.IndexOf(second);

            if (firstIndex > secondIndex)
            {
                int temp = firstIndex;
                firstIndex = secondIndex;
                secondIndex = temp;
            }

            var recordsBetween = new List<RecordBase>();

            for(var i = firstIndex + 1; i < secondIndex; i++)
            {
                if (_records[i].RecordName == recordName)
                    recordsBetween.Add(_records[i]);
            }

            return recordsBetween;
        }

        public int GetTotal(string fieldClassName, RecordBase first, RecordBase second, string recordClassName)
        {
            if (first == null || second == null)
                return -1;

            var recordList = GetRecordsBetween(first, second, recordClassName);
            var sum = 0;

            foreach (var record in recordList)
            {
                var matchClassName = fieldClassName.Replace(Constants.TotalStr, "");
                matchClassName = record.ClassName.Substring(0, 3) + matchClassName.Substring(3);
                var field = record.GetField(matchClassName);

                if (field != null)
                {
                    Int32.TryParse(field.DataInRecordBuffer(), out int value);
                    sum += value;

                }
            }

            return sum;
        }

        public int GetRecordsFeildsSum(string fieldClassName, RecordBase record, string summationRecordName)
        {
            var rceRecord = GetPrecedRecord(record, RecordNameEnum.Rce.ToString());

            if (rceRecord != null)
            {
                return GetTotal(fieldClassName, record, rceRecord, summationRecordName);
            }

            return 0;
        }

        public int GetTaxYear(RecordBase record)
        {
            var rceRecord = GetPrecedRecord(record, RecordNameEnum.Rce.ToString()) as RceRecord;

            if (rceRecord == null)
                throw new Exception($"Rce Record is not provided");

            return rceRecord.GetTaxYear();
        }

        public void WriteToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var record in _records)
                {
                    writer.Write(new string(record.RecordBuffer));
                }
            }
        }

        public List<string> ReadFromFile(string fileName)
        {
            var bufferList = new List<string>();

            using (StreamReader reader = new StreamReader(fileName))
            {

                var buffer = reader.ReadToEnd();
                if(buffer.Length % Constants.RecordLength != 0 )
                    throw new Exception($"file is not correct :{fileName} ");

                for (int i = 0; i < buffer.Length; i += Constants.RecordLength)
                {
                    bufferList.Add(buffer.Substring(i, Constants.RecordLength));
                }
            }

            return bufferList;
        }

        public static RecordManager CreateManager(List<string> recordBufferList)
        {
            var manager = new RecordManager();

            foreach (var recordBuffer in recordBufferList)
            {
                var recordName = recordBuffer.Substring(0, 1) + recordBuffer.Substring(1, 2).ToLower() + recordBuffer.Substring(3).ToLower();
                Enum.TryParse(recordName, out RecordNameEnum recordNameEnum);

                switch (recordNameEnum)
                {
                    case RecordNameEnum.Rca:
                        manager.AddRecord(new RcaRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rce:
                        manager.AddRecord(new RceRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rcw:
                        manager.AddRecord(new RcwRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rco:
                        manager.AddRecord(new RcoRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rcs:
                        manager.AddRecord(new RcsRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rct:
                        manager.AddRecord(new RctRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rcu:
                        manager.AddRecord(new RcuRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rcv:
                        manager.AddRecord(new RcvRecord(manager, recordBuffer.ToCharArray()));
                        break;
                    case RecordNameEnum.Rcf:
                        manager.AddRecord(new RcfRecord(manager, recordBuffer.ToCharArray()));
                        break;
                }
            }
            return manager; 
        }
    }

}
