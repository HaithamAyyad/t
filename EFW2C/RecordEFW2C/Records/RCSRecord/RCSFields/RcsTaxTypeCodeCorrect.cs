﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcsTaxTypeCodeCorrect : FieldCorrect
    {
        public RcsTaxTypeCodeCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 462;
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