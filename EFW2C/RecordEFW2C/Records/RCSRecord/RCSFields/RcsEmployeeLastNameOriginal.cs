using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcsEmployeeLastNameOriginal : FieldOriginal
    {
        public RcsEmployeeLastNameOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 63;
            _length = 20;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsEmployeeLastNameOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
