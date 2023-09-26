﻿using EFW2C.Common.Constants;
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

            CloneData(rceRecord);

            return rceRecord;
        }

        public void AddRcwRecord(RcwRecord rcwRecord)
        {
            if (_isLocked)
                throw new Exception($"Employer record is locked");

            if (_rcwRecordList.Count + 1 > Constants.MaxRcwRecordsNumber)
                throw new Exception($"Employee records should not exceed {Constants.MaxRcwRecordsNumber}");

            if (!rcwRecord.IsLocked)
                throw new Exception($"Employee record is unlocked");

            _rcwRecordList.Add((RcwRecord)rcwRecord.Clone(Manager));
        }

        public void SetRcvRecord(RcvRecord rcvRecord)
        {
            if (_isLocked)
                throw new Exception($"Employer record is locked");

            _rcvRecord = null;

            if (rcvRecord != null)
            {
                if (!rcvRecord.IsLocked)
                    throw new Exception($"State record is unlocked");

                _rcvRecord = (RcvRecord)rcvRecord.Clone(Manager);
            }
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
