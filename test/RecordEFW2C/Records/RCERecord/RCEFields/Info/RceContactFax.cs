﻿using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RceContactFax : ContactFaxBase
    {
        public RceContactFax(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 274;
            _length = 10;
        }
    }
}