using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsTaxingEntityCodeCorrect : FieldCorrect
    {
        public RcsTaxingEntityCodeCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 10;
            _length = 5;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsTaxingEntityCodeCorrect(record, _data);
        }
    }
}
