﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    public class RcwRetirementPlanIndicatorOriginal : FieldOriginal
    {
        public RcwRetirementPlanIndicatorOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 1004;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}