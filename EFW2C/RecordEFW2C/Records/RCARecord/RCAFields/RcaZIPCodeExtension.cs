﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaZipCodeExtension : ZipCodeExtensionBase
    {
        public RcaZipCodeExtension(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 161;
            _length = 4;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaZipCodeExtension(record, _data);
        }
    }
}
