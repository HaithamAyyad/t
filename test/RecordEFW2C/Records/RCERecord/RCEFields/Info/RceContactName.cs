using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-1-2023
    //Reviewed by : 

    public class RceContactName : ContactNameBase
    {
        public RceContactName(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 227;
            _length = 27;
        }
    }
}
