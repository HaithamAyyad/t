using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceCity : CityBase
    {
        public RceCity(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 144;
            _length = 22;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceCity(record, _data);
        }
    }
}