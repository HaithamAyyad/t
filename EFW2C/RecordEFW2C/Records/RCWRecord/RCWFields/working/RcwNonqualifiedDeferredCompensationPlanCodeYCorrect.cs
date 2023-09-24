using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    internal class RcwNonqualifiedDeferredCompensationPlanCodeYCorrect : MoneyCorrect
    {
        public RcwNonqualifiedDeferredCompensationPlanCodeYCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 760;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwNonqualifiedDeferredCompensationPlanCodeYCorrect(record, _data);
        }
    }
}

