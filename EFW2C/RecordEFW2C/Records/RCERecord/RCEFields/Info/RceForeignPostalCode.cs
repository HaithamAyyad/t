﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    internal class RceForeignPostalCode : ForeignPostalCodeBase
    {
        public RceForeignPostalCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 204;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceForeignPostalCode(record, _data);
        }
    }
}
