using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Fields;
using EFW2C.Records;

namespace EFW2C.Manager
{
    internal class RecordManager
    {
        private bool _isOpened;
        private bool _isVerified;

        private bool _reSubmitted;
        private bool _unemployment;
        private bool _isTIB;

        private RcaRecord _rcaRecord;
        private RcfRecord _rcfRecord;
        private List<RceRecord> _rceRecordList;

        public bool IsOpened { get { return _isOpened; } }
        public bool IsVerified { get { return _isVerified; } }
        public bool IsTIB { get { return _isTIB; } }

        public RecordManager()
        {
            _rceRecordList = new List<RceRecord>();
            _rcfRecord = new RcfRecord(this);

            _isOpened = true;

            WageTaxHelper.CreateWageTaxTabel();

        }

        public void SetRcaRecord(RcaRecord rcaRecord)
        {
            CheckOpened(true);

            _rcaRecord = null;

            if (rcaRecord != null)
            {
                if (!rcaRecord.IsLocked)
                    throw new Exception($"Submitter is unlocked");

                _rcaRecord = (RcaRecord)rcaRecord.Clone(this);
            }
        }

        public void AddRceRecord(RceRecord rceRecord)
        {
            CheckOpened(true);

            if (rceRecord == null)
                return;

            if (_rceRecordList.Count + 1 > Constants.MaxRceRecordsNumber)
                throw new Exception($"Employer records should not exceed {Constants.MaxRceRecordsNumber}");

            if (!rceRecord.IsLocked)
                throw new Exception($"Empoyer record is unlocked");

            _rceRecordList.Add((RceRecord) rceRecord.Clone(this));
        }

        public void Open()
        {
            _isVerified = false;
            _isOpened = true;
        }

        private void CheckOpened(bool isOpened)
        {
            if (isOpened)
            {
                if (!_isOpened)
                    throw new Exception($"Document is Closed");
            }
            else
            {
                if (_isOpened)
                    throw new Exception($"Document is Opened");
            }
        }

        public bool Verify()
        {
            _isVerified = false;

            if (GetRcwRecordsCount() > Constants.MaxRcwRecordsNumber)
                throw new Exception($"Employee records should not exceed {Constants.MaxRcwRecordsNumber}");

            if (GetRceRecordsCount() > Constants.MaxRceRecordsNumber)
                throw new Exception($"Employer records should not exceed {Constants.MaxRceRecordsNumber}");

            if (!_rcaRecord.IsVerified && !_rcaRecord.Verify())
                return false;

            if (_rceRecordList.Count == 0)
                throw new Exception($"At least one Employer records should be provided");

            foreach (var rceRecord in _rceRecordList)
            {
                if (!rceRecord.IsVerified && !rceRecord.Verify())
                    return false;
            }

            if (!_rcfRecord.IsVerified && !_rcfRecord.Verify())
                return false;

            if (!VerifyFieldsInRecords())
                return false;

            _isVerified = true;

            return _isVerified;
        }

        public void Close()
        {
            if (!_isOpened)
                return;

            foreach (var rceRecord in _rceRecordList)
            {
                rceRecord.GenerateTotalRecords();
                rceRecord.GenerateTotalOptionalRecords();
            }

            PrepareRcfRecord();

            _isOpened = false;

            try
            {
                Verify();
            }
            catch(Exception ex)
            {
                _isOpened = true;
                throw ex;
            }

        }

        private void PrepareRcfRecord()
        {
            _rcfRecord.Lock(false);
            _rcfRecord.Reset();
            _rcfRecord.AddField(new RcfIdentifierField(_rcfRecord));
            _rcfRecord.AddField(new RcfNumberOfRCWRecord(_rcfRecord));
            _rcfRecord.Write();
            _rcfRecord.Lock();
        }

        public int GetRcwRecordsCount()
        {
            int rcwNumber = 0;

            foreach (var rceRecord in _rceRecordList)
                rcwNumber += rceRecord.RcwRecordList.Count();

            return rcwNumber;
        }

        public int GetRceRecordsCount()
        {
            return _rceRecordList.Count();
        }

        public RecordManager Clone()
        {
            CheckOpened(false);

            var manager = new RecordManager()
            {
                _reSubmitted = _reSubmitted,
                _unemployment = _unemployment,
                _isTIB = _isTIB,
            };

            manager._rcaRecord = _rcaRecord;
            manager._rcfRecord = _rcfRecord;

            manager._rceRecordList = new List<RceRecord>();

            foreach (var rceRecord in _rceRecordList)
            {
                manager._rceRecordList.Add((RceRecord)rceRecord.Clone(manager));
            }

            return manager;
        }

        private bool VerifyFieldsInRecords()
        {
            CheckOpened(false);

            if (!RecordBase.AreFieldsBelongToRecord(_rcaRecord, _rcaRecord.Fields))
                return false;

            foreach (var rceRecord in _rceRecordList)
            {
                if (!RecordBase.AreFieldsBelongToRecord(rceRecord, rceRecord.Fields))
                    return false;

                foreach (var rcwRecord in rceRecord.RcwRecordList)
                {
                    if (!RecordBase.AreFieldsBelongToRecord(rcwRecord, rcwRecord.Fields))
                        return false;

                    if (rcwRecord.RcoRecord != null)
                    {
                        if (!RecordBase.AreFieldsBelongToRecord(rcwRecord.RcoRecord, rcwRecord.RcoRecord.Fields))
                            return false;
                    }

                    if (rcwRecord.RcsRecord != null)
                    {
                        if (!RecordBase.AreFieldsBelongToRecord(rcwRecord.RcsRecord, rcwRecord.RcsRecord.Fields))
                            return false;
                    }
                }

                if (!RecordBase.AreFieldsBelongToRecord(rceRecord.RctRecord, rceRecord.RctRecord.Fields))
                    return false;

                if (rceRecord.RcuRecord != null)
                {
                    if (!RecordBase.AreFieldsBelongToRecord(rceRecord.RcuRecord, rceRecord.RcuRecord.Fields))
                        return false;
                }

                if (rceRecord.RcvRecord != null)
                {
                    if (!RecordBase.AreFieldsBelongToRecord(rceRecord.RcvRecord, rceRecord.RcvRecord.Fields))
                        return false;
                }
            }

            return true;
        }

        public void SetSubmitter(bool value)
        {
            CheckOpened(true);
            _reSubmitted = value;
            
        }

        public void SetUnEmployment(bool value)
        {
            CheckOpened(true);

            _unemployment = value;
        }

        public void SetUnTIB(bool value)
        {
            CheckOpened(true);

            _isTIB = value;
        }

        public bool IsSubmitter()
        {
            return _reSubmitted;
        }

        public bool IsUnEmployment()
        {
            return _unemployment;
        }

        public void WriteToFile(string fileName)
        {
            CheckOpened(false);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(new string(_rcaRecord.RecordBuffer));

                foreach (var rceRecord in _rceRecordList)
                {
                    writer.Write(new string(rceRecord.RecordBuffer));
                    
                    foreach (var rcwRecord in rceRecord.RcwRecordList)
                    {
                        writer.Write(new string(rcwRecord.RecordBuffer));
                        
                        if(rcwRecord.RcoRecord != null)
                            writer.Write(new string(rcwRecord.RcoRecord.RecordBuffer));

                        if(rcwRecord.RcsRecord != null)
                            writer.Write(new string(rcwRecord.RcsRecord.RecordBuffer));
                    }

                    writer.Write(new string(rceRecord.RctRecord.RecordBuffer));

                    if(rceRecord.RcuRecord != null)
                        writer.Write(new string(rceRecord.RcuRecord.RecordBuffer));

                    if(rceRecord.RcvRecord != null)
                        writer.Write(new string(rceRecord.RcvRecord.RecordBuffer));
                }

                writer.Write(new string(_rcfRecord.RecordBuffer));
            }
        }

        public static List<string> ReadFromFile(string fileName)
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

        public static RecordManager CreateManager(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                    throw new Exception($"File {fileName} is not exists");

                var manager = new RecordManager();

                var recordBufferList = ReadFromFile(fileName);

                var recordList = RecordBase.CreateRecordList(manager, recordBufferList);

                try
                {
                    RecordsOrderHelper.VerifyRecordsOrder(recordList);
                }
                catch(Exception ex)
                {
                    throw new Exception($"Invaild file {fileName} : { ex.Message}");
                }

                recordList[0].Lock();
                manager.SetRcaRecord((RcaRecord)recordList[0]);

                var index = 1;

                while(recordList[index] is RceRecord rceRecord)
                {
                    index++;
                    while(recordList[index] is RcwRecord rcwRecord)
                    {
                        index++;
                        if (recordList[index] is RcoRecord rcoRecord)
                        {
                            rcoRecord.Lock();
                            rcwRecord.SetRcoRecord(rcoRecord);
                            index++;
                        }

                        if (recordList[index] is RcsRecord rcsRecord)
                        {
                            rcsRecord.Lock();
                            rcwRecord.SetRcsRecord(rcsRecord);
                            index++;
                        }

                        rcwRecord = rceRecord.AddRcwRecord(rcwRecord, true);
                        rcwRecord.Lock();
                    }

                    //since RctRecord is are auto generated 
                    if (recordList[index] is RctRecord rctRecord)
                        index++;

                    //since RcuRecord is auto generated 
                    if (recordList[index] is RcuRecord rcuRecord)
                        index++;

                    if (recordList[index] is RcvRecord rcvRecord)
                    {
                        rcvRecord.Lock();
                        rceRecord.SetRcvRecord(rcvRecord);
                        index++;
                    }

                    rceRecord.Lock(true);
                    manager.AddRceRecord(rceRecord);
                }

                if (recordList[index] as RcfRecord == null)
                    throw new Exception($"RcfRecord is not provided");

                manager.Close();

                return manager;
            }
            catch (Exception ex)
            {
                throw new Exception($"Create Manager faild, {ex.Message}");
            }
        }
    }
}
