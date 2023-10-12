﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-4-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsStateAbbreviation : StateAbbreviationBase
    {
        public RcsStateAbbreviation(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 199;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsStateAbbreviation(record, _data);
        }
    }
}
