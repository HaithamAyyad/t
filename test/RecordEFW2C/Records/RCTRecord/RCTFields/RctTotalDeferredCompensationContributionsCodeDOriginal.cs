﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-8-2023
    //Reviewed by : 

    public class RctTotalDeferredCompensationContributionsCodeDOriginal : SumFieldOriginal
    {
        public RctTotalDeferredCompensationContributionsCodeDOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 280;
            _length = 15;
        }
    }
}
