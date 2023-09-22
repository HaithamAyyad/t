using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaZIPCodeExtension : ZIPCodeExtensionBase
    {
        public RcaZIPCodeExtension(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 161;
            _length = 4;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaZIPCodeExtension(record, _data);
        }
    }
}
