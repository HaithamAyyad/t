﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class RcoUncollectedEmployeeTaxOnTipsCodesABCorrect : FieldCorrect
    {
        public RcoUncollectedEmployeeTaxOnTipsCodesABCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 45;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
