using EFW2C.Common.Enums;
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

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (250, 30),
                (370, 654)
            };
        }

        protected override List<FieldBase> CreateChildClassFields()
        {
            return new List<FieldBase>
            {
                new RcuIdentifierField(this),
                new RcuNumberOfRCORecord(this),
                new RcuTotalAllocatedTipsCorrect(this),
                new RcuTotalAllocatedTipsOriginal(this),
            };
        }
    }
}
