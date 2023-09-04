using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-3-2023
    //Reviewed by : 

    public class RcaContactFax : ContactFaxBase
    {
        public RcaContactFax(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 304;
            _length = 10;
        }
    }
}
