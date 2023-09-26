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

            PrepareRcfRecord();

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
                throw new Exception($"Employer  records should not exceed {Constants.MaxRceRecordsNumber}");

            if (!_rcaRecord.IsVerified && !_rcaRecord.Verify())
                return false;

            foreach(var rceRecord in _rceRecordList)
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

            PrepareRcfRecord();

            Verify();

            _isOpened = false;
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
            /*
            CheckLock(true);

            var manager = new RecordManager()
            {
                _reSubmitted = _reSubmitted,
                _unemployment = _unemployment,
                _isTIB = _isTIB,
            };

            foreach (var record in _records)
                manager.AddRecord(record.Clone(manager));

            return manager;
            */

            return null;
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

        public void WriteToFile_1(string fileName)
        {
            /*
            CheckLock(true);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var record in _records)
                {
                    writer.Write(new string(record.RecordBuffer));
                }
            }
            */
        }

        public List<string> ReadFromFile_1(string fileName)
        {
            /*
            CheckLock(false);

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
            */

            return null;
        }

        public static RecordManager CreateManager_1(string fileName)
        {
            /*
            try
            {
                if (!File.Exists(fileName))
                    throw new Exception($"File {fileName} is not exists");

                var manager = new RecordManager();

                var recordBufferList = manager.ReadFromFile(fileName);

                foreach (var recordBuffer in recordBufferList)
                {
                    var recordName = recordBuffer.Substring(0, 1) + recordBuffer.Substring(1, 2).ToLower();
                    var recordNameEnum = Enum.Parse(typeof(RecordNameEnum), recordName);

                    var record = null as RecordBase;

                    switch (recordNameEnum)
                    {
                        case RecordNameEnum.Rca:
                            record = new RcaRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rce:
                            record = new RceRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rcw:
                            record = new RcwRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rco:
                            record = new RcoRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rcs:
                            record = new RcsRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rct:
                            record = new RctRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rcu:
                            record = new RcuRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rcv:
                            record = new RcvRecord(manager, recordBuffer.ToCharArray());
                            break;
                        case RecordNameEnum.Rcf:
                            record = new RcfRecord(manager, recordBuffer.ToCharArray());
                            break;
                    }

                    if (record != null)
                    {
                        manager.AddRecord(record);
                        record.CreateFieldsFromRecordBuffer();

                        if (record is RcaRecord rcaRecord)
                        {
                            var rcaResubIndicator = record.GetField(typeof(RcaResubIndicator).Name);

                            if (!FieldBase.IsFieldNullOrWhiteSpace(rcaResubIndicator))
                                manager.SetSubmitter(rcaResubIndicator.DataInRecordBuffer() == "1");
                        }

                    }
                }

                manager.Verify();

                return manager;
            }
            catch (Exception ex)
            {
                throw new Exception($"Create Manager faild, {ex.Message}");
            }
            */

            return null;
        }
    }
}
