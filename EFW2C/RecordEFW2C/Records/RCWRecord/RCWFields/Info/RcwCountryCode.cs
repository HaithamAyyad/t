using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    internal class RcwCountryCode : CountryCodeBase
    {
        public RcwCountryCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 241;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwCountryCode(record, _data);
        }
    }
}
