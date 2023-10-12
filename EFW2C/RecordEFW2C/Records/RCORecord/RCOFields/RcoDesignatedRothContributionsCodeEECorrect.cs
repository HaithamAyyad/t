﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-6-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcoDesignatedRothContributionsCodeEECorrect : MoneyCorrect
    {
        public RcoDesignatedRothContributionsCodeEECorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 221;
            _length = 11;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new RcoDesignatedRothContributionsCodeEECorrect(record, _data);
        }
    }
}
