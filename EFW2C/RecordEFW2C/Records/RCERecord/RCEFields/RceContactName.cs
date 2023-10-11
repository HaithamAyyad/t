using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceContactName : ContactNameBase
    {
        public RceContactName(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 227;
            _length = 27;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceContactName(record, _data);
        }
    }
}
