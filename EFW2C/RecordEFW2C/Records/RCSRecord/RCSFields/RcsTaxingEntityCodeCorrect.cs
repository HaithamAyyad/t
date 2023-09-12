using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcsTaxingEntityCodeCorrect : FieldCorrect
    {
        public RcsTaxingEntityCodeCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 10;
            _length = 5;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
