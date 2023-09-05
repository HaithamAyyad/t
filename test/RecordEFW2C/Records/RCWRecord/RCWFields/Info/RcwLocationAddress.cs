﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RcwLocationAddress : LocationAddressBase
    {
        public RcwLocationAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 121;
            _length = 22;
        }
    }
}