﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class RcoUncollectedSocialSecurityOrRRTATaxCodeMCorrect : FieldCorrect
    {
        public RcoUncollectedSocialSecurityOrRRTATaxCodeMCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 133;
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
