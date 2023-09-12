using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaForeignPostalCode : ForeignPostalCodeBase
    {
        public RcaForeignPostalCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 194;
            _length = 15;
        }
    }
}
