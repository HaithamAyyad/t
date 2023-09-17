﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : HSA 9-17-2023

    internal class RcwDeferredCompensationCodeDOriginal : MoneyOriginal
    {
        public RcwDeferredCompensationCodeDOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 441;
            _length = 11;
        }
    }
}
