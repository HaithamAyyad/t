using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaContactPhone : ContactPhoneBase
    {
        public RcaContactPhone(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 238;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaContactPhone(record, _data);
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
