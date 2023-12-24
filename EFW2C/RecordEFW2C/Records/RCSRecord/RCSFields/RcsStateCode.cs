using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsStateCode : StateBase
    {
        public RcsStateCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsStateCode(record, _data);
        }
    }
}

