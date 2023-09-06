﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2013
    //Reviewed by : 

    public class RcaContactPhone : ContactPhoneBase
    {
        public RcaContactPhone(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 238;
            _length = 15;
        }
        public override bool IsRequired()
        {
            return true;
        }
    }
}
