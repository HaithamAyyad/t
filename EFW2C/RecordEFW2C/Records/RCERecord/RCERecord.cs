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

        public int GetTaxYear()
        {
            var taxYearField = GetField(typeof(RceTaxYear).Name);
            if (FieldBase.IsFieldNullOrWhiteSpace(taxYearField))
                throw new Exception($"{ClassName}: tax year field is not provided");

            return int.Parse(taxYearField.DataInRecordBuffer());
        }
    }
}
