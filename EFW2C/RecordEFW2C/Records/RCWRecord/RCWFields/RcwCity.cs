using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-4-2023
    //Reviewed by : Has 10-12-2023

    internal class RcwCity : CityBase
    {
        public RcwCity(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 165;
            _length = 22;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwCity(record, _data);
        }
    }
}