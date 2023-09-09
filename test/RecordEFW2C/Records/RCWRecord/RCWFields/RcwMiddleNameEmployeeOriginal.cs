﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    public class RcwMiddleNameEmployeeOriginal : FieldOriginal
    {
        public RcwMiddleNameEmployeeOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 36;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
