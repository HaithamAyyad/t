using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceZipCodeExtension : ZipCodeExtensionBase
    {
        public RceZipCodeExtension(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 173;
            _length = 4;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceZipCodeExtension(record, _data);
        }
    }
}
