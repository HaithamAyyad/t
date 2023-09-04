using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCORecord : RecordBase
    {
        public RCORecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCO.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (3, 9),
                (188, 22),
                (276, 748)
            };
        }

        protected override List<FieldBase> CreateRequiredFields()
        {
            return new List<FieldBase>
            {
                new RcoIdentifierField(this)
            };
        }
    }
}
