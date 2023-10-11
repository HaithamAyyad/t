using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-3-2023
    //Reviewed by : Hsa 10-10-2023 

    internal class RcaContactFax : ContactFaxBase
    {
        public RcaContactFax(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 304;
            _length = 10;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaContactFax(record, _data);
        }
    }
}
