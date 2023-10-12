﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsStateIncomeTaxWithheldCorrect : MoneyCorrect
    {
        public RcsStateIncomeTaxWithheldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 430;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsStateIncomeTaxWithheldCorrect(record, _data);
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
