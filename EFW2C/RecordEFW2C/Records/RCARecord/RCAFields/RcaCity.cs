﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaCity : CityBase
    {
        public RcaCity(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 132;
            _length = 22;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaCity(record, _data);
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}