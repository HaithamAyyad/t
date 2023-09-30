﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    internal class RceContactPhoneExtension : ContactPhoneExtensionBase
    {
        public RceContactPhoneExtension(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 269;
            _length = 5;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceContactPhoneExtension(record, _data);
        }
    }
}