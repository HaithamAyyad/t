using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RcaRecord : RecordBase
    {
        public RcaRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rca.ToString())
        {
            AddField(new RcaIdentifier(this));
        }
        
        public RcaRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rca.ToString(), buffer)
        {
            AddField(new RcaIdentifier(this));
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcaRecord = new RcaRecord(manager);

            CloneData(rcaRecord);

            return rcaRecord;
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

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcaCity(this, "Helper"),
                new RcaContactEMailInternet(this, "Helper"),
                new RcaContactFax(this, "Helper"),
                new RcaContactName(this, "Helper"),
                new RcaContactPhone(this, "Helper"),
                new RcaContactPhoneExtension(this, "Helper"),
                new RcaCountryCode(this, "Helper"),
                new RcaDeliveryAddress(this, "Helper"),
                new RcaEinSubmitter(this, "Helper"),
                new RcaForeignPostalCode(this, "Helper"),
                new RcaForeignStateProvince(this, "Helper"),
                new RcaIdentifier(this),
                new RcaLocationAddress(this, "Helper"),
                new RcaPreparerCode(this, "Helper"),
                new RcaResubIndicator(this, "Helper"),
                new RcaResubWageFile(this, "Helper"),
                new RcaSoftwareCode(this, "Helper"),
                new RcaSoftwareVendorCode(this, "Helper"),
                new RcaStateAbbreviation(this, "Helper"),
                new RcaSubmitterName(this, "Helper"),
                new RcaUserIdentification(this, "Helper"),
                new RcaZipCode(this, "Helper"),
                new RcaZipCodeExtension(this, "Helper"),
            };
        }
    }
}
