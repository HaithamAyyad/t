﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    internal class RceLocationAddress : LocationAddressBase
    {
        public RceLocationAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 100;
            _length = 22;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceLocationAddress(record, _data);
        }
    }
}