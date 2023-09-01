using EFW2C.Common.Enum;
using EFW2C.Fields;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCARecord : RecordBase
    {
        public RCARecord()
        {
            RecordName = RecordNameEnum.RCA.ToString();
        }

        protected override void CreateLinkedFields()
        {
            _linkedFields = new List<Tuple<FieldBase, FieldBase>>();
            _linkedFields.Add(Tuple.Create<FieldBase, FieldBase>(new RcaSoftwareVendorCode(null, "dummy"),
                                                                 new RcaSoftwareCode(null, "dummy")));
        }
        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            _requiredFields.Add(new RcaIdentifierField(null, "dummy"));
            _requiredFields.Add(new RcaSubmitterEinField(null, "dummy"));
            _requiredFields.Add(new RcaUserIdentification(null, "dummy"));
            _requiredFields.Add(new RcaSubmitterName(null, "dummy"));
        }
    }
}
