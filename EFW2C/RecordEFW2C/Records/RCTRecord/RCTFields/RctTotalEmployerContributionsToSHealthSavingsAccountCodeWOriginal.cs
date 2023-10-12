using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-8-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RctTotalEmployerContributionsToSHealthSavingsAccountCodeWOriginal : SumFieldOriginal
    {
        public RctTotalEmployerContributionsToSHealthSavingsAccountCodeWOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 520;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalEmployerContributionsToSHealthSavingsAccountCodeWOriginal(record);
        }
    }
}
