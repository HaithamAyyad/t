using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwEmployeeLastNameCorrect : FieldCorrect
    {
        public RcwEmployeeLastNameCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 101;
            _length = 20;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwEmployeeLastNameCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
