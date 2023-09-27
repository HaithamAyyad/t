using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    internal class RcaZipCode : ZipCodeBase
    {
        public RcaZipCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 156;
            _length = 5;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaZipCode(record, _data);
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}