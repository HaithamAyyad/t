﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RcwStateAbbreviation : StateAbbreviationBase
    {
        public RcwStateAbbreviation(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 187;
            _length = 2;
        }
    }
}