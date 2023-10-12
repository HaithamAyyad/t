using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-4-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwForeignPostalCode : ForeignPostalCodeBase
    {
        public RcwForeignPostalCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 226;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwForeignPostalCode(record, _data);
        }
    }
}
