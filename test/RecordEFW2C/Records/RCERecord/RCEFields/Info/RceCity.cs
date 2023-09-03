using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-1-2023
    //Reviewed by : 

    public class RceCity : CityBase
    {
        public RceCity(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 144;
            _length = 22;
        }
    }
}