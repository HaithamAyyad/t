﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RcwEmployeeFirstNameCorrect : FieldCorrect
    {
        public RcwEmployeeFirstNameCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 71;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwEmployeeFirstNameCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
