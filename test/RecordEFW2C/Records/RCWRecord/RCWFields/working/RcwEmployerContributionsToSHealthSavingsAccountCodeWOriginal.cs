using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcwEmployerContributionsToSHealthSavingsAccountCodeWOriginal : MoneyOriginal
    {
        public RcwEmployerContributionsToSHealthSavingsAccountCodeWOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 617;
            _length = 11;
        }
    }
}
