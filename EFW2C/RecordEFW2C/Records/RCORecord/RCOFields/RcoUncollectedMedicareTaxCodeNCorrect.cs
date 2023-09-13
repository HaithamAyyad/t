﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class RcoUncollectedMedicareTaxCodeNCorrect : MoneyCorrect
    {
        public RcoUncollectedMedicareTaxCodeNCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 155;
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