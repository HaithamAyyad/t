﻿using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-3-2023
    //Reviewed by : 

    public class RceForeignStateProvince : ForeignStateProvinceBase
    {
        public RceForeignStateProvince(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 181;
            _length = 23;
        }
    }
}