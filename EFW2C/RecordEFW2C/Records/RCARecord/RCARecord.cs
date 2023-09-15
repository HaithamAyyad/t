using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcaRecord : RecordBase
    {
        public RcaRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rca.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)> 
            { 
                (24, 5), 
                (165, 6), 
                (258, 3), 
                (301, 3), 
                (314, 1), 
                (323, 701) 
            };
        }

        protected override List<FieldBase> CreateVerifyFieldsList()
        {
            return new List<FieldBase>
            {
                new RcaCity(this, "dummy"),
                new RcaContactEMailInternet(this, "dummy"),
                new RcaContactFax(this, "dummy"),
                new RcaContactName(this, "dummy"),
                new RcaContactPhone(this, "dummy"),
                new RcaContactPhoneExtension(this, "dummy"),
                new RcaCountryCode(this, "dummy"),
                new RcaDeliveryAddress(this, "dummy"),
                new RcaEinSubmitterField(this, "dummy"),
                new RcaForeignPostalCode(this, "dummy"),
                new RcaForeignStateProvince(this, "dummy"),
                new RcaIdentifierField(this),
                new RcaLocationAddress(this, "dummy"),
                new RcaPreparerCode(this, "dummy"),
                new RcaResubIndicator(this, "dummy"),
                new RcaResubWageFile(this, "dummy"),
                new RcaSoftwareCode(this, "dummy"),
                new RcaSoftwareVendorCode(this, "dummy"),
                new RcaStateAbbreviation(this, "dummy"),
                new RcaSubmitterName(this, "dummy"),
                new RcaUserIdentification(this, "dummy"),
                new RcaZIPCode(this, "dummy"),
                new RcaZIPCodeExtension(this, "dummy"),
            };
        }
    }
}
