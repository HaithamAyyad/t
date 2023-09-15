using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcfRecord : RecordBase
    {
        public RcfRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rcf.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (12, 1012)
            };
        }

        protected override List<FieldBase> CreateVerifyFieldsList()
        {
            return new List<FieldBase>
            {
                new RcfIdentifierField(this),
                new RcfNumberOfRCWRecord(this)
            };
        }
    }
}
