using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwNontaxableCombatPayCodeQOriginal : MoneyOriginal
    {
        public RcwNontaxableCombatPayCodeQOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 661;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwNontaxableCombatPayCodeQOriginal(record, _data);
        }
    }
}
