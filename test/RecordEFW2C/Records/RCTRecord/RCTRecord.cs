using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCTRecord : RecordBase
    {
        public RCTRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCT.ToString();
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            _requiredFields.Add(new RctIdentifierField(this));
        }
    }
}
