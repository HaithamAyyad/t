using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-3-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaForeignStateProvince : ForeignStateProvinceBase
    {
        public RcaForeignStateProvince(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 171;
            _length = 23;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaForeignStateProvince(record, _data);
        }
    }
}
