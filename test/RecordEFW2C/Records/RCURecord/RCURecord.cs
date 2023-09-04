using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCURecord : RecordBase
    {
        public RCURecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCU.ToString();
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            _requiredFields.Add(new RcuIdentifierField(this));
        }
    }
}
