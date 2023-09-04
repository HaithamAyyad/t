using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-42023
    //Reviewed by : 

    public class RcwForeignStateProvince : ForeignStateProvinceBase
    {
        public RcwForeignStateProvince(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 203;
            _length = 23;
        }
    }
}
