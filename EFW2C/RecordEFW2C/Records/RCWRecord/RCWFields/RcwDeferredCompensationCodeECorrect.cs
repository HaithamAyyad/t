﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : HSA 9-17-2023

    internal class RcwDeferredCompensationCodeECorrect : MoneyCorrect
    {
        public RcwDeferredCompensationCodeECorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 474;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwDeferredCompensationCodeECorrect(record, _data);
        }
    }
}
