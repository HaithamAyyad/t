﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-8-2023
    //Reviewed by : Hsa 10-12-2-23

    internal class RcuTotalAggregateDeferralsCodeHHOriginal : SumFieldOriginal
    {
        public RcuTotalAggregateDeferralsCodeHHOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 340;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcuTotalAggregateDeferralsCodeHHOriginal(record);
        }
    }
}
