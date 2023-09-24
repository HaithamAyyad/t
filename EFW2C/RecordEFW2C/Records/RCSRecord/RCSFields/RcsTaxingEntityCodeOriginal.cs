using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    internal class RcsTaxingEntityCodeOriginal : FieldOriginal
    {
        public RcsTaxingEntityCodeOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 5;
            _length = 5;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new RcsTaxingEntityCodeOriginal(record, _data);
        }


        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
