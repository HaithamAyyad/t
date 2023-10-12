using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwEmployeeLastNameOriginal : FieldOriginal
    {
        public RcwEmployeeLastNameOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 51;
            _length = 20;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwEmployeeLastNameOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
