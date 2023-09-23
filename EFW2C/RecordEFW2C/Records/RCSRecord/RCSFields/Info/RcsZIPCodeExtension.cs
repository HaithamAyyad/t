using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RcsZipCodeExtension : ZipCodeExtensionBase
    {
        public RcsZipCodeExtension(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 206;
            _length = 4;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsZipCodeExtension(record, _data);
        }
    }
}
