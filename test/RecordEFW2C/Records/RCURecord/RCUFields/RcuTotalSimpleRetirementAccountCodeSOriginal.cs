﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-8-2023
    //Reviewed by : 

    public class RcuTotalSimpleRetirementAccountCodeSOriginal : SumFieldOriginal
    {
        public RcuTotalSimpleRetirementAccountCodeSOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 100;
            _length = 15;
        }
    }
}