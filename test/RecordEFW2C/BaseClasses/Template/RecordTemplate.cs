using EFW2C.Common.Enum;
using EFW2C.Fields;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RecordTemplate : RecordBase
    {
        public RecordTemplate()
        {
            RecordName = null;
        }

        protected override void CreateLinkedFields()
        {
            _linkedFields = new List<Tuple<FieldBase, FieldBase>>();
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            //_requiredFields.Add(new RcaIdentifierField(null, null));
        }
    }
}
