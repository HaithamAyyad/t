using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-1-2023
    //Reviewed by : 

    public class RcaContactName : ContactNameBase
    {
        public RcaContactName(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 211;
            _length = 27;
        }
    }
}
