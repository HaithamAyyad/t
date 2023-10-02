﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal abstract class SocialSecurityNumberOriginal : FieldOriginal
    {
        public SocialSecurityNumberOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
            _fieldFormat = FieldFormat.Hyphen;
        }
    }
}