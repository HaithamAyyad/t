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

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            _requiredFields.Add(new RcaIdentifierField(this));
            _requiredFields.Add(new RcaSubmitterEinField(this, "dummy"));
            _requiredFields.Add(new RcaUserIdentification(this, "dummy"));
            _requiredFields.Add(new RcaSubmitterName(this, "dummy"));
            _requiredFields.Add(new RcaContactName(this, "dummy"));
            _requiredFields.Add(new RcaLocationAddress(this, "dummy"));
            _requiredFields.Add(new RcaDeliveryAddress(this, "dummy"));
            _requiredFields.Add(new RcaCity(this, "dummy"));
            _requiredFields.Add(new RcaStateAbbreviation(this, "dummy"));
            _requiredFields.Add(new RcaZIPCode(this, "dummy"));
            _requiredFields.Add(new RcaForeignPostalCode(this, "dummy"));
            _requiredFields.Add(new RcaForeignStateProvince(this, "dummy"));
            _requiredFields.Add(new RcaCountryCode(this, "dummy"));
            _requiredFields.Add(new RcaSoftwareVendorCode(this, "dummy"));
            _requiredFields.Add(new RcaContactPhone(this, "dummy"));
            _requiredFields.Add(new RcaContactEMailInternet(this, "dummy"));
            _requiredFields.Add(new RcaResubIndicator(this, "dummy"));
            _requiredFields.Add(new RcaResubWageFile(this, "dummy"));
        }
    }
}
