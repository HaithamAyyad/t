using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-4-2023
    //Reviewed by : 

    internal class RcsForeignStateProvince : ForeignStateProvinceBase
    {
        public RcsForeignStateProvince(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 215;
            _length = 23;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsForeignStateProvince(record, _data);
        }
    }
}
