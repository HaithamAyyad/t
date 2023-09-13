﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Has 9-3-2023
    //Reviewed by : 

    public class RcfIdentifierField : IdentifierFieldBase
    {
        public RcfIdentifierField(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }
    }
}