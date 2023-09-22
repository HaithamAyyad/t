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
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rce.ToString();
        }

        public RceRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, buffer)
        {
            RecordName = RecordNameEnum.Rce.ToString();
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
                new RceZIPCode(this, "dummy"),
                new RceZIPCodeExtension(this, "dummy"),
            };
        }

        public int GetTaxYear()
        {
            var taxYearField = GetField(typeof(RceTaxYear).Name);

            if (taxYearField == null)
                throw new Exception($"{ClassName}: tax year field is not provided");

            var taxYearData = taxYearField.DataInRecordBuffer();

            if (string.IsNullOrWhiteSpace(taxYearData))
                throw new Exception($"{ClassName}: tax year is not provided");

            return Int32.Parse(taxYearData);
        }
    }
}
