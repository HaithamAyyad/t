using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RecordTemplate : RecordBase
    {
        public RecordTemplate(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = null;
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            //_requiredFields.Add(new RcaIdentifierField(this, "dummy"));
        }
    }
}
