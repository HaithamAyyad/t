using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCERecord : RecordBase
    {
        public RCERecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCE.ToString();
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            _requiredFields.Add(new RceIdentifierField(this));
            _requiredFields.Add(new RceTaxYear(this,"dummy"));
        }
    }
}
