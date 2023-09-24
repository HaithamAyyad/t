﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    internal class SumFieldOriginalTemplate : SumFieldOriginal
    {
        public SumFieldOriginalTemplate(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = -1;
            _length = -1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new SumFieldOriginalTemplate(record);
        }

    }
}
