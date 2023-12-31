﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsEmployeeMiddleNameOriginal : FieldOriginal
    {
        public RcsEmployeeMiddleNameOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 48;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsEmployeeMiddleNameOriginal(record, _data);
        }
    }
}

