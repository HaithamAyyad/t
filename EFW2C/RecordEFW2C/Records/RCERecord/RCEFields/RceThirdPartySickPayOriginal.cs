using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal class RceThirdPartySickPayOriginal : FieldOriginal
    {
        public RceThirdPartySickPayOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 223;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceThirdPartySickPayOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
