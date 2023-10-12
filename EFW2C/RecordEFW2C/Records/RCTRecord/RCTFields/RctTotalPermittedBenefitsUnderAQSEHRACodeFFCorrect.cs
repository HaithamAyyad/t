﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-8-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RctTotalPermittedBenefitsUnderAQSEHRACodeFFCorrect : SumFieldCorrect
    {
        public RctTotalPermittedBenefitsUnderAQSEHRACodeFFCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 835;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalPermittedBenefitsUnderAQSEHRACodeFFCorrect(record);
        }
    }
}
