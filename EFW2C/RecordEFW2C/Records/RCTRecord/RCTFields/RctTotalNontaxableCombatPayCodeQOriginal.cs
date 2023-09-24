using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-8-2023
    //Reviewed by : 

    internal class RctTotalNontaxableCombatPayCodeQOriginal : SumFieldOriginal
    {
        public RctTotalNontaxableCombatPayCodeQOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 580;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalNontaxableCombatPayCodeQOriginal(record);
        }
    }
}
