using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-6-2023
    //Reviewed by : 

    internal class RcuTotalAllocatedTipsOriginal : SumFieldOriginal
    {
        public RcuTotalAllocatedTipsOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 10;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcuTotalAllocatedTipsOriginal(record);
        }
    }
}