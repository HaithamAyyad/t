using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCWRecord : RecordBase
    {
        public RCWRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCW.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (198, 5),
                (397, 22),
                (573, 22),
                (583, 22),
                (859, 143)
            };
        }

        protected override List<FieldBase> CreateRequiredFields()
        {
            return new List<FieldBase>
            {
                new RcwIdentifierField(this),
                new RcwLocationAddress(this, "dummy"),
                new RcwDeliveryAddress(this, "dummy"),
                new RcwCity(this, "dummy"),
                new RcwStateAbbreviation(this, "dummy"),
                new RcwZIPCode(this, "dummy"),
                new RcwForeignPostalCode(this, "dummy"),
                new RcwForeignStateProvince(this, "dummy"),
                new RcwCountryCode(this, "dummy")
            };
        }
    }
}
