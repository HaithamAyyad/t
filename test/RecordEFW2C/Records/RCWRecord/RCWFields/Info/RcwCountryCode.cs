using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RcwCountryCode : CountryCodeBase
    {
        public RcwCountryCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 241;
            _length = 2;
        }
    }
}
