using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCARecord : RecordBase
    {
        public RCARecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCA.ToString();
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

        protected override List<FieldBase> CreateRequiredFields()
        {
            return new List<FieldBase>
            {
                new RcaIdentifierField(this),
                new RcaEinSubmitterField(this, "dummy"),
                new RcaUserIdentification(this, "dummy"),
                new RcaSubmitterName(this, "dummy"),
                new RcaContactName(this, "dummy"),
                new RcaLocationAddress(this, "dummy"),
                new RcaDeliveryAddress(this, "dummy"),
                new RcaCity(this, "dummy"),
                new RcaStateAbbreviation(this, "dummy"),
                new RcaZIPCode(this, "dummy"),
                new RcaForeignPostalCode(this, "dummy"),
                new RcaForeignStateProvince(this, "dummy"),
                new RcaCountryCode(this, "dummy"),
                new RcaSoftwareVendorCode(this, "dummy"),
                new RcaContactPhone(this, "dummy"),
                new RcaContactEMailInternet(this, "dummy"),
                new RcaResubIndicator(this, "dummy"),
                new RcaResubWageFile(this, "dummy")
            };
        }
    }
}
