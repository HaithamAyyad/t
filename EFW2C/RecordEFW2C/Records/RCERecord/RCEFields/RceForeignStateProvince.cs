using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-3-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceForeignStateProvince : ForeignStateProvinceBase
    {
        public RceForeignStateProvince(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 181;
            _length = 23;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceForeignStateProvince(record, _data);
        }
    }
}
