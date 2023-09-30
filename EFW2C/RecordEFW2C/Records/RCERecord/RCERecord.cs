using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RceRecord : RecordBase
    {
        private List<RcwRecord> _rcwRecordList;
        private RctRecord _rctRecord;
        private RcuRecord _rcuRecord;
        private RcvRecord _rcvRecord;

        public List<RcwRecord> RcwRecordList { get { return _rcwRecordList; } }
        public RctRecord RctRecord { get { return _rctRecord; } }
        public RcuRecord RcuRecord { get { return _rcuRecord; } }
        public RcvRecord RcvRecord { get { return _rcvRecord; } }

        public RceRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rce.ToString())
        {
            AddField(new RceIdentifierField(this));

            _rcwRecordList = new List<RcwRecord>();
        }

        public RceRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rce.ToString(), buffer)
        {
            AddField(new RceIdentifierField(this));

            _rcwRecordList = new List<RcwRecord>();
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rceRecord = new RceRecord(manager);

            if (_rctRecord != null)
                rceRecord.SetRctRecord((RctRecord)_rctRecord.Clone(manager), true);

            if (_rcuRecord != null)
                rceRecord.SetRcuRecord((RcuRecord)_rcuRecord.Clone(manager), true);

            if (_rcvRecord != null)
                rceRecord.SetRcvRecord((RcvRecord)_rcvRecord.Clone(manager), true);

            rceRecord._rcwRecordList = new List<RcwRecord>();

            foreach (var rcwRecord in _rcwRecordList)
            {
                var rcwRecordCloned = (RcwRecord)rcwRecord.Clone(manager);
                rceRecord._rcwRecordList.Add(rcwRecordCloned);
            }

            CloneData(rceRecord);

            return rceRecord;
        }

        public RcwRecord AddRcwRecord(RcwRecord rcwRecord, bool cloneMode = false)
        {
            if (_isLocked)
                throw new Exception($"Employer record is locked");

            if (_rcwRecordList.Count + 1 > Constants.MaxRcwRecordsNumber)
                throw new Exception($"Employee records should not exceed {Constants.MaxRcwRecordsNumber}");

            if (!cloneMode && !rcwRecord.IsLocked)
                throw new Exception($"Employee record is unlocked");

            var rcwRecordCloned = (RcwRecord)rcwRecord.Clone(Manager);
            rcwRecordCloned.SetParent(this);
            _rcwRecordList.Add(rcwRecordCloned);

            return rcwRecordCloned;
        }

        public void SetRcuRecord(RcuRecord rcuRecord, bool cloneMode = false)
        {
            if (_isLocked)
                throw new Exception($"Employer record is locked");

            if (_rcuRecord != null)
                _rcuRecord.SetParent(null);

            _rcuRecord = null;

            if (!cloneMode && !rcuRecord.IsLocked)
                throw new Exception($"Total Option record is unlocked");

            _rcuRecord = (RcuRecord)rcuRecord.Clone(Manager);

            _rcuRecord.SetParent(this);
        }

        public void SetRctRecord(RctRecord rctRecord, bool cloneMode = false)
        {
            if (_isLocked)
                throw new Exception($"Employer record is locked");

            if (_rctRecord != null)
                _rctRecord.SetParent(null);

            _rctRecord = null;

            if (!cloneMode && !rctRecord.IsLocked)
                throw new Exception($"Total record is unlocked");

            _rctRecord = (RctRecord)rctRecord.Clone(Manager);

            _rctRecord.SetParent(this);
        }

        public void SetRcvRecord(RcvRecord rcvRecord, bool cloneMode = false)
        {
            if (_isLocked)
                throw new Exception($"Employer record is locked");

            if (_rcvRecord != null)
                _rcvRecord.SetParent(null);

            _rcvRecord = null;

            if (rcvRecord != null && !rcvRecord.IsRecordEmpty())
            {
                if (!cloneMode && !rcvRecord.IsLocked)
                    throw new Exception($"State record is unlocked");

                _rcvRecord = (RcvRecord)rcvRecord.Clone(Manager);

                _rcvRecord.SetParent(this);
            }
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var found = false;

            if (_rcvRecord != null)
            {
                foreach (var rcwRecord in _rcwRecordList)
                {
                    if (rcwRecord.RcsRecord != null)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new Exception($"State total record should not be provided since state record is not provided");
            }

            return true;
        }

        public int GetTaxYear()
        {
            var taxYearField = GetField(typeof(RceTaxYear).Name);
            if (FieldBase.IsFieldNullOrWhiteSpace(taxYearField))
                throw new Exception($"{ClassName}: tax year field is not provided");

            return int.Parse(taxYearField.DataInRecordBuffer());
        }

        public int GetRcwFieldsSum(string fieldClassName)
        {
            var sum = 0;

            foreach (var rcwRecord in _rcwRecordList)
            {
                var field = rcwRecord.GetField(fieldClassName);

                if (field != null)
                    sum += Int32.Parse(field.DataInRecordBuffer());
            }

            return sum;
        }

        public int GetRcoFieldsSum(string fieldClassName)
        {
            var sum = 0;

            foreach (var rcwRecord in _rcwRecordList)
            {
                if (rcwRecord.RcoRecord != null)
                {
                    var field = rcwRecord.RcoRecord.GetField(fieldClassName);

                    if (field != null)
                        sum += Int32.Parse(field.DataInRecordBuffer());
                }
            }

            return sum;
        }

        public void GenerateTotalOptionalRecords()
        {
            bool found = false;

            foreach (var rcwRecord in _rcwRecordList)
            {
                if (rcwRecord.RcoRecord != null)
                {
                    found = true;
                    break;
                }
            }

            _rcuRecord = null;

            if (found)
            {
                var rcuRecord = new RcuRecord(Manager);

                rcuRecord.Reset();
                rcuRecord.SetParent(this);

                foreach (var rcuField in rcuRecord.HelperFieldsList)
                    rcuRecord.AddField(rcuField.Clone(rcuRecord));

                rcuRecord.Write();

                if (!rcuRecord.IsRecordEmpty())
                    _rcuRecord = rcuRecord;
            }
        }

        public void GenerateTotalRecords()
        {
            _rctRecord = new RctRecord(Manager);
            _rctRecord.Reset();
            _rctRecord.SetParent(this);

            foreach (var rctField in _rctRecord.HelperFieldsList)
                _rctRecord.AddField(rctField.Clone(_rctRecord));

            _rctRecord.Write();
        }

        public string GetEmploymentCode()
        {
            var employmentCodeField = GetField(typeof(RceEmploymentCodeCorrect).Name);
            return employmentCodeField?.DataInRecordBuffer();
        }

        public int GetRcwRecordsCount()
        {
            return _rcwRecordList.Count;
        }

        public int GetRcoRecordsCount()
        {
            int count = 0;
            foreach(var rcwRecord in _rcwRecordList)
                count += rcwRecord.RcoRecord != null ? 1 : 0;

            return count;
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (177, 4),
                (225, 1),
                (324, 700)
            };
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RceAgentIndicator(this, "Helper"),
                new RceCity(this, "Helper"),
                new RceContactEMailInternet(this, "Helper"),
                new RceContactFax(this, "Helper"),
                new RceContactName(this, "Helper"),
                new RceContactPhone(this, "Helper"),
                new RceContactPhoneExtension(this, "Helper"),
                new RceCountryCode(this, "Helper"),
                new RceDeliveryAddress(this, "Helper"),
                new RceEinAgent(this, "Helper"),
                new RceEinAgentFederal(this, "Helper"),
                new RceEinAgentFederalOriginal(this, "Helper"),
                new RceEmployerName(this, "Helper"),
                new RceEmploymentCodeCorrect(this, "Helper"),
                new RceEmploymentCodeOriginal(this, "Helper"),
                new RceEstablishmentNumberCorrect(this, "Helper"),
                new RceEstablishmentNumberOriginal(this, "Helper"),
                new RceForeignPostalCode(this, "Helper"),
                new RceForeignStateProvince(this, "Helper"),
                new RceIdentifierField(this),
                new RceKindOfEmployer(this, "Helper"),
                new RceLocationAddress(this, "Helper"),
                new RceStateAbbreviation(this, "Helper"),
                new RceTaxYear(this, "Helper"),
                new RceThirdPartySickPayCorrect(this, "Helper"),
                new RceThirdPartySickPayOriginal(this, "Helper"),
                new RceZipCode(this, "Helper"),
                new RceZipCodeExtension(this, "Helper"),
            };
        }
    }
}
