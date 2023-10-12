using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-5-2023
    //Reviewed by : Hsa 10-11-2023

    internal abstract class SocialSecurityNumberCorrect : FieldCorrect
    {
        public SocialSecurityNumberCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
            _fieldFormat = FieldFormat.Hyphen;
        }
    }
}