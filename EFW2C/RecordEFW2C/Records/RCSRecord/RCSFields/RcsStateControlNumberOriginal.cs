﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsStateControlNumberOriginal : FieldOriginal
    {
        public RcsStateControlNumberOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 485;
            _length = 7;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsStateControlNumberOriginal(record, _data);
        }
        //Applies to Income Tax reporting.
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
