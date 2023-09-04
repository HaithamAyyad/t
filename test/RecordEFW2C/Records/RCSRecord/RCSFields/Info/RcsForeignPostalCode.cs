﻿using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RcsForeignPostalCode : ForeignPostalCodeBase
    {
        public RcsForeignPostalCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 238;
            _length = 15;
        }
    }
}
