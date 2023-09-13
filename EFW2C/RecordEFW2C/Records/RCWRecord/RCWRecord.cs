using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcwRecord : RecordBase
    {
        public RcwRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rcw.ToString();
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

        protected override List<FieldBase> CreateChildClassFields()
        {
            return new List<FieldBase>
            {
                new RcwCity(this, "dummy"),
                new RcwCountryCode(this, "dummy"),
                new RcwDeliveryAddress(this, "dummy"),
                new RcwForeignPostalCode(this, "dummy"),
                new RcwForeignStateProvince(this, "dummy"),
                new RcwIdentifierField(this),
                new RcwLocationAddress(this, "dummy"),
                new RcwStateAbbreviation(this, "dummy"),
                new RcwZIPCode(this, "dummy"),
                new RcwZIPCodeExtension(this, "dummy"),
                new RcwSocialSecurityNumberOriginal(this, "dummy"),
                new RcwSocialSecurityNumberCorrect(this, "dummy"),
                new RcwSocialSecurityTaxWithheldCorrect(this, "dummy"),
                new RcwSocialSecurityTaxWithheldOriginal(this, "dummy"),
        };
        }
    }
}
