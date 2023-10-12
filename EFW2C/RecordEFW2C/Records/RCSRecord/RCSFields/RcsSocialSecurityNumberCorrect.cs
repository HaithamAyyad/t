using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RcsSocialSecurityNumberCorrect : SocialSecurityNumberCorrect
    {
        public RcsSocialSecurityNumberCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos =  24;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsSocialSecurityNumberCorrect(record, _data);
        }
    }
}
