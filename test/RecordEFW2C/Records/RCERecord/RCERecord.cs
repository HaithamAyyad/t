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

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (177, 4),
                (225, 1),
                (324, 700)
            };
        }

        protected override List<FieldBase> CreateRequiredFields()
        {
            return new List<FieldBase>
            {
                new RceIdentifierField(this),
                new RceTaxYear(this, "dummy"),
                new RceKindOfEmployer(this, "dummy")
            };
        }
    }
}
