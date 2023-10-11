﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaLocationAddress : LocationAddressBase
    {
        public RcaLocationAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 88;
            _length = 22;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaLocationAddress(record, _data);
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
