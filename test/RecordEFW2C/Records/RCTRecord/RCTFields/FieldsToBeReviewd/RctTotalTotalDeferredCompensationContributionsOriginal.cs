﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RctTotalTotalDeferredCompensationContributionsOriginal : SumFieldOriginal
    {
        public RctTotalTotalDeferredCompensationContributionsOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 430;
            _length = 15;
        }
    }
}