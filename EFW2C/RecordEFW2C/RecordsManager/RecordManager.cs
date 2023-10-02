using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EFW2C.Common.Constants;
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
        public bool IsSubmitter { get { return _reSubmitted; } }
        public bool IsUnEmployment { get { return _unemployment; } }

        public List<RceRecord> RceRecordList { get { return _rceRecordList; } }

        public RecordManager()
        {
            _rceRecordList = new List<RceRecord>();
            _rcfRecord = new RcfRecord(this);

            _isOpened = true;

            WageTaxHelper.CreateWageTaxTabel();
        }

        public void SetRcaRecord(RcaRecord rcaRecord)
        {
            _rcaRecord = rcaRecord;

            SetDirty1();
        }

        private void SetDirty1()
        {
            _isVerified = false;
        }

        public void AddRceRecord(RceRecord rceRecord)
        {
            if (rceRecord != null)
            {
                if (_rceRecordList.Count + 1 > Constants.MaxRceRecordsNumber)
                    throw new Exception($"Employer records should not exceed {Constants.MaxRceRecordsNumber}");

                _rceRecordList.Add(rceRecord);
                SetDirty1();
            }
        }

        public void Open()
        {
            _isOpened = true;
            SetDirty1();
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

            if (!_rcaRecord.Verify())
                return false;

            if (_rceRecordList.Count == 0)
                throw new Exception($"At least one Employer records should be provided");

            foreach (var rceRecord in _rceRecordList)
            {
                if (!rceRecord.Verify())
                    return false;
            }

            if (!_isOpened)
            {
                if (!_rcfRecord.Verify())
                    return false;
            }

            if (!VerifyFieldsInRecords())
                return false;

            _isVerified = true;

            return _isVerified;
        }

        public void Close()
        {
            if (!_isOpened)
                return;

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
            _rcfRecord.Reset();
            _rcfRecord.AddField(new RcfRecordIdentifier(_rcfRecord));
            _rcfRecord.AddField(new RcfNumberOfRCWRecord(_rcfRecord));
            _rcfRecord.Write();
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
            var manager = new RecordManager()
            {
                _reSubmitted = _reSubmitted,
                _unemployment = _unemployment,
                _isTIB = _isTIB,
            };

            manager.SetRcaRecord((RcaRecord)_rcaRecord.Clone(manager));

            manager._rceRecordList = new List<RceRecord>();

            foreach (var rceRecord in _rceRecordList)
                manager._rceRecordList.Add((RceRecord)rceRecord.Clone(manager));

            return manager;
        }

        private bool VerifyFieldsInRecords()
        {
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

            if (_rcfRecord != null)
            {
                if (!RecordBase.AreFieldsBelongToRecord(_rcfRecord, _rcfRecord.Fields))
                    return false;
            }

            return true;
        }

        public void SetSubmitter(bool value)
        {
            if (_reSubmitted != value)
            {
                _reSubmitted = value;
                SetDirty1();
            }
        }

        public void SetUnEmployment(bool value)
        {
            if (_unemployment != value)
            {
                _unemployment = value;
                SetDirty1();
            }
        }

        public void SetTIB(bool value)
        {
            if (_isTIB != value)
            {
                _isTIB = value;
                SetDirty1();
            }
        }

        private List<RecordBase> CreateRecordList()
        {
            var recordList = new List<RecordBase>();

            recordList.Add(_rcaRecord);

            foreach (var rceRecord in _rceRecordList)
            {
                recordList.Add(rceRecord);

                foreach (var rcwRecord in rceRecord.RcwRecordList)
                {
                    recordList.Add(rcwRecord);

                    if (rcwRecord.RcoRecord != null && !rcwRecord.RcoRecord.IsRecordEmpty())
                        recordList.Add(rcwRecord.RcoRecord);

                    if (rcwRecord.RcsRecord != null)
                        recordList.Add(rcwRecord.RcsRecord);
                }

                recordList.Add(rceRecord.RctRecord);

                if (rceRecord.RcuRecord != null)
                    recordList.Add(rceRecord.RcuRecord);

                if (rceRecord.RcvRecord != null && !rceRecord.RcvRecord.IsRecordEmpty())
                    recordList.Add(rceRecord.RcvRecord);
            }

            recordList.Add(_rcfRecord);

            return recordList;
        }

        public void WriteToFile(string fileName)
        {
            CheckOpened(false);

            var recordList = CreateRecordList();

            RecordsOrderHelper.VerifyRecordsOrder(recordList);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(var record in recordList)
                    writer.Write(new string(record.RecordBuffer));
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
                            rcwRecord.SetRcoRecord(rcoRecord);
                            index++;
                        }

                        if (recordList[index] is RcsRecord rcsRecord)
                        {
                            rcwRecord.SetRcsRecord(rcsRecord);
                            index++;
                        }

                        rceRecord.AddRcwRecord(rcwRecord);
                    }

                    //since RctRecord is auto generated, we don't add it. 
                    if (recordList[index] is RctRecord rctRecord)
                        index++;

                    //since RcuRecord is auto generated, we don't add ot 
                    if (recordList[index] is RcuRecord rcuRecord)
                        index++;

                    if (recordList[index] is RcvRecord rcvRecord)
                    {
                        rceRecord.SetRcvRecord(rcvRecord);
                        index++;
                    }

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
