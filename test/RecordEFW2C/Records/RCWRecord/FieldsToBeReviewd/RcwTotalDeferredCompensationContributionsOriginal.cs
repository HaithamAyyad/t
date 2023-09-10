using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    //testing only to see difference on source tree.
    public class RcwTotalDeferredCompensationContributionsOriginal : MoneyOriginal
    {
        public RcwTotalDeferredCompensationContributionsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 551;
            _length = 11;
        }
    }
}
