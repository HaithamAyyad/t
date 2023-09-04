using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCSRecord : RecordBase
    {
        public RCSRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCS.ToString();
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            _requiredFields.Add(new RcsIdentifierField(this));
            _requiredFields.Add(new RcsLocationAddress(this, "dummy"));
            _requiredFields.Add(new RcsDeliveryAddress(this, "dummy"));
            _requiredFields.Add(new RcsCity(this, "dummy"));
            _requiredFields.Add(new RcsStateAbbreviation(this, "dummy"));
            _requiredFields.Add(new RcsZIPCode(this, "dummy"));
            _requiredFields.Add(new RcsForeignPostalCode(this, "dummy"));
            _requiredFields.Add(new RcsForeignStateProvince(this, "dummy"));
            _requiredFields.Add(new RcsCountryCode(this, "dummy"));
        }
    }
}
