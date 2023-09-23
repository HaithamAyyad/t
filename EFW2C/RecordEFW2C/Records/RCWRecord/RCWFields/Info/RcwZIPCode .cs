using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RcwZipCode : ZipCodeBase
    {
        public RcwZipCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 189;
            _length = 5;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwZipCode(record, _data);
        }
    }
}