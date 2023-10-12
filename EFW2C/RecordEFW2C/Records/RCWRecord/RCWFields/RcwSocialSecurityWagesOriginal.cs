using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwSocialSecurityWagesOriginal : MoneyOriginal
    {
        public RcwSocialSecurityWagesOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 287;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityWagesOriginal(record, _data);
        }
    }
}
