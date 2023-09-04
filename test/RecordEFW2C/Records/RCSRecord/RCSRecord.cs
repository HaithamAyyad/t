using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCSRecord : RecordBase
    {
        public RCSRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCS.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (210, 5),
                (269, 6),
                (383, 12),
                (799, 225)
            };
        }

        protected override List<FieldBase> CreateRequiredFields()
        {
            return new List<FieldBase>
            {
                new RcsIdentifierField(this),
                new RcsLocationAddress(this, "dummy"),
                new RcsDeliveryAddress(this, "dummy"),
                new RcsCity(this, "dummy"),
                new RcsStateAbbreviation(this, "dummy"),
                new RcsZIPCode(this, "dummy"),
                new RcsForeignPostalCode(this, "dummy"),
                new RcsForeignStateProvince(this, "dummy"),
                new RcsCountryCode(this, "dummy")
            };
        }
    }
}
