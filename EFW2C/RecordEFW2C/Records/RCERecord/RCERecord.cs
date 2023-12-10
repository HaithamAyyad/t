using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Fields;
using EFW2C.Languages;
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
            Prepare();

            _rcwRecordList = new List<RcwRecord>();
        }

        public RceRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rce.ToString(), buffer)
        {
            Prepare();

            _rcwRecordList = new List<RcwRecord>();
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rceRecord = new RceRecord(manager);

            CloneData(rceRecord);

            if (_rcvRecord != null)
                rceRecord.SetRcvRecord((RcvRecord)_rcvRecord.Clone(manager));

            rceRecord._rcwRecordList = new List<RcwRecord>();

            foreach (var rcwRecord in _rcwRecordList)
                rceRecord.AddRcwRecord((RcwRecord)rcwRecord.Clone(manager));

            return rceRecord;
        }

        public void AddRcwRecord(RcwRecord rcwRecord)
        {
            if (rcwRecord != null && !_rcwRecordList.Contains(rcwRecord))
            {
                if (_rcwRecordList.Count + 1 > Constants.MaxRcwRecordsNumber)
                    throw new Exception(Error.Instance.GetError("Employer ", Error.Instance.RecordsShouldNotExceed, Constants.MaxRcwRecordsNumber));

                rcwRecord.SetParent(this);
                _rcwRecordList.Add(rcwRecord);

                _rctRecord = null;
                _rcuRecord = null;
            }
        }

        public void SetRcuRecord(RcuRecord rcuRecord)
        {
            if (_rcuRecord != null)
                _rcuRecord.SetParent(null);

            _rcuRecord = rcuRecord;

            if (_rcuRecord != null)
                _rcuRecord.SetParent(this);
        }

        public void SetRctRecord(RctRecord rctRecord)
        {
            if (_rctRecord != null)
                _rctRecord.SetParent(null);

            _rctRecord = rctRecord;

            if (_rctRecord != null)
                _rctRecord.SetParent(this);
        }

        public void SetRcvRecord(RcvRecord rcvRecord)
        {
            if (_rcvRecord != null)
                _rcvRecord.SetParent(null);

            _rcvRecord = rcvRecord;

            if (rcvRecord != null)
                _rcvRecord.SetParent(this);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            foreach (var rcwRecord in _rcwRecordList)
            {
                if (!rcwRecord.Verify())
                    return false;
            }

            GenerateEmployeeTotalRecords();

            GenerateTotalEmployeeOptionalRecords();

            if (!_rctRecord.Verify())
                return false;

            if (_rcuRecord != null)
            {
                if (!_rcuRecord.Verify())
                    return false;
            }

            if (!IsRecordNullOrEmpty(_rcvRecord) && !IsRcsRecordExists())
                throw new Exception(Error.Instance.GetError(Error.Instance.Remove, "State-Total record ", "or add State record")); 
            
            return true;
        }

        private bool IsRcsRecordExists()
        {
            foreach (var rcwRecord in _rcwRecordList)
            {
                if (rcwRecord.RcsRecord != null)
                    return true;
            }

            return false;
        }

        private bool IsRcoRecordExists()
        {
            foreach (var rcwRecord in _rcwRecordList)
            {
                if (rcwRecord.RcoRecord != null)
                    return true;
            }

            return false;
        }

        public int GetTaxYear()
        {
            var taxYearField = GetField(typeof(RceTaxYear).Name);
            if (FieldBase.IsFieldNullOrWhiteSpace(taxYearField))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.CantBeBlank));

            return int.Parse(taxYearField.DataInRecordBuffer());
        }

        public decimal GetRcwFieldsSum(string fieldClassName)
        {
            decimal sum = 0;
            var atLeastOne = false;

            foreach (var rcwRecord in _rcwRecordList)
            {
                var field = rcwRecord.GetField(fieldClassName);

                if (field != null)
                {
                    atLeastOne = true;
                    sum += decimal.Parse(field.DataInRecordBuffer());
                }
            }

            return atLeastOne ? sum : -1;
        }

        public decimal GetRcoFieldsSum(string fieldClassName)
        {
            decimal sum = 0;
            var atLeastOne = false;

            foreach (var rcwRecord in _rcwRecordList)
            {
                if (rcwRecord.RcoRecord != null)
                {
                    var field = rcwRecord.RcoRecord.GetField(fieldClassName);

                    if (field != null)
                    {
                        atLeastOne = true;
                        sum += decimal.Parse(field.DataInRecordBuffer());
                    }
                }
            }

            return atLeastOne? sum: -1;
        }

        public void GenerateEmployeeTotalRecords()
        {
            var rctRecord = new RctRecord(Manager);

            foreach (var rctField in rctRecord.HelperFieldsList)
            {
                if (IsRcwMatchRctFieldExists(rctField.ClassName))
                    rctRecord.AddField(rctField.Clone(rctRecord));
            }

            rctRecord.AddField(new RctNumberOfRCWRecords(rctRecord));


            SetRctRecord(rctRecord);
            rctRecord.Write();
        }

        public void GenerateTotalEmployeeOptionalRecords()
        {
            _rcuRecord = null;

            if (IsRcoRecordExists())
            {
                var rcuRecord = new RcuRecord(Manager);

                foreach (var rcuField in rcuRecord.HelperFieldsList)
                {
                    if (IsRcoMatchRcuFieldExists(rcuField.ClassName))
                        rcuRecord.AddField(rcuField.Clone(rcuRecord));
                }

                rcuRecord.AddField(new RcuNumberOfRCORecords(rcuRecord));

                rcuRecord.SetParent(this);
                rcuRecord.Write();
                if (!rcuRecord.IsRecordEmpty())
                    SetRcuRecord(rcuRecord);
            }
        }

        private bool IsRcwMatchRctFieldExists(string fieldName)
        {
            fieldName = $"{RecordNameEnum.Rcw}{fieldName.Substring(3)}";

            if (fieldName.Contains(Constants.OriginalStr) || fieldName.Contains(Constants.CorrectStr))
            {
                fieldName = fieldName.ReplaceFirstOccurrence(Constants.TotalStr, "");

                foreach (var rcwRecord in _rcwRecordList)
                {
                    if (rcwRecord.GetField(fieldName) != null)
                        return true;
                }
            }

            return false;
        }

        private bool IsRcoMatchRcuFieldExists(string fieldName)
        {
            fieldName = $"{RecordNameEnum.Rco}{fieldName.Substring(3)}";

            if (fieldName.Contains(Constants.OriginalStr) || fieldName.Contains(Constants.CorrectStr))
            {
                fieldName = fieldName.ReplaceFirstOccurrence(Constants.TotalStr, "");
                foreach (var rcwRecord in _rcwRecordList)
                {
                    if (rcwRecord.RcoRecord?.GetField(fieldName) != null)
                        return true;
                }
            }

            return false;
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

        protected override List<Tuple<int, int>> CreateBlankList()
        {
            return new List<Tuple<int, int>>
            {
                new Tuple<int, int>(177, 4),
                new Tuple<int, int>(225, 1),
                new Tuple<int, int>(324, 700)
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
                new RceRecordIdentifier(this),
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
