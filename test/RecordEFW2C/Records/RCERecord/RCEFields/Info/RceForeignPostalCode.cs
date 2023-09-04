﻿using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RceForeignPostalCode : ForeignPostalCodeBase
    {
        public RceForeignPostalCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 204;
            _length = 15;
        }
    }
}