using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCWRecord : RecordBase
    {
        public RCWRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCW.ToString();
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();
            
            _requiredFields.Add(new RcwIdentifierField(this));
            _requiredFields.Add(new RcwLocationAddress(this, "dummy"));
            _requiredFields.Add(new RcwDeliveryAddress(this, "dummy"));
            _requiredFields.Add(new RcwCity(this, "dummy"));
            _requiredFields.Add(new RcwStateAbbreviation(this, "dummy"));
            _requiredFields.Add(new RcwZIPCode(this, "dummy"));
            _requiredFields.Add(new RcwForeignPostalCode(this, "dummy"));
            _requiredFields.Add(new RcwForeignStateProvince(this, "dummy"));
            _requiredFields.Add(new RcwCountryCode(this, "dummy"));
        }
    }
}
