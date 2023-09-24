using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RceRecord : RecordBase
    {
        public RceRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rce.ToString())
        {
        }

        public RceRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rce.ToString(), buffer)
        {
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rceRecord = new RceRecord(manager);

            CloneData(rceRecord, manager);

            return rceRecord;
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

        protected override List<FieldBase> CreateVerifyFieldsList()
        {
            return new List<FieldBase>
            {
                new RceAgentIndicator(this, "dummy"),
                new RceCity(this, "dummy"),
                new RceContactEMailInternet(this, "dummy"),
                new RceContactFax(this, "dummy"),
                new RceContactName(this, "dummy"),
                new RceContactPhone(this, "dummy"),
                new RceContactPhoneExtension(this, "dummy"),
                new RceCountryCode(this, "dummy"),
                new RceDeliveryAddress(this, "dummy"),
                new RceEinAgent(this, "dummy"),
                new RceEinAgentFederal(this, "dummy"),
                new RceEinAgentFederalOriginal(this, "dummy"),
                new RceEmployerName(this, "dummy"),
                new RceEmploymentCodeCorrect(this, "dummy"),
                new RceEmploymentCodeOriginal(this, "dummy"),
                new RceEstablishmentNumberCorrect(this, "dummy"),
                new RceEstablishmentNumberOriginal(this, "dummy"),
                new RceForeignPostalCode(this, "dummy"),
                new RceForeignStateProvince(this, "dummy"),
                new RceIdentifierField(this),
                new RceKindOfEmployer(this, "dummy"),
                new RceLocationAddress(this, "dummy"),
                new RceStateAbbreviation(this, "dummy"),
                new RceTaxYear(this, "dummy"),
                new RceThirdPartySickPayCorrect(this, "dummy"),
                new RceThirdPartySickPayOriginal(this, "dummy"),
                new RceZipCode(this, "dummy"),
                new RceZipCodeExtension(this, "dummy"),
            };
        }

        public int GetTaxYear()
        {
            var taxYearField = GetField(typeof(RceTaxYear).Name);
            if (FieldBase.IsFieldNullOrWhiteSpace(taxYearField))
                throw new Exception($"{ClassName}: tax year field is not provided");

            return int.Parse(taxYearField.DataInRecordBuffer());
        }
    }
}
