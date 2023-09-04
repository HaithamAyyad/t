﻿using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaContactPhoneExtension : ContactPhoneExtensionBase
    {
        public RcaContactPhoneExtension(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 253;
            _length = 5;
        }
    }
}