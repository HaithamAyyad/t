using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    internal class RceCountryCode : CountryCodeBase
    {
        public RceCountryCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 219;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceCountryCode(record, _data);
        }
    }
}
