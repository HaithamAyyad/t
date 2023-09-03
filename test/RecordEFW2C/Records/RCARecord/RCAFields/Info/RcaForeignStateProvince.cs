using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-3-2023
    //Reviewed by : 

    public class RcaForeignStateProvince : ForeignStateProvinceBase
    {
        public RcaForeignStateProvince(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 171;
            _length = 23;
        }
    }
}
