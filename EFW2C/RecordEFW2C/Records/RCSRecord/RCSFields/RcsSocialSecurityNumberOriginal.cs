using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    internal class RcsSocialSecurityNumberOriginal : FieldOriginal
    {
        public RcsSocialSecurityNumberOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 15;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsSocialSecurityNumberOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
