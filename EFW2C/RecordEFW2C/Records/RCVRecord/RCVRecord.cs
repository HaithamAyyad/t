using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcvRecord : RecordBase
    {
        public RcvRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rcv.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return null;
        }

        protected override List<FieldBase> CreateChildClassFields()
        {
            return new List<FieldBase>
            {
                new RcvIdentifierField (this),
                new RcvSupplementalData(this, "dummy"),
            };
        }
    }
}
