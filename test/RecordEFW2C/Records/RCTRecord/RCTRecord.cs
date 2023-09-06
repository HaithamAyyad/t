using EFW2C.Common.Enums;
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
            LinkName = RecordNameEnum.RCW.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (220, 30),
                (460, 30),
                (850, 174)
            };
        }

        protected override List<FieldBase> CreateChildClassFields()
        {
            return new List<FieldBase>
            {
                new RctIdentifierField(this)
            };
        }
    }
}
