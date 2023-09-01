﻿using System;

using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-1-2023
    //Reviewed by : HSA on ........

    public class RcaUserIdentification : FieldBase
    {
        public RcaUserIdentification(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 12;
            _length = 8;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        protected override bool IsNumeric()
        {
            return false;
        }

        protected override bool IsUpperCase()
        {
            return true;
        }
    }
}
