using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : HSA 9-17-2023

    internal class RcwTotalDeferredCompensationContributionsOriginal : MoneyOriginal
    {
        public RcwTotalDeferredCompensationContributionsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 551;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if(!_record.Manager.IsTIB)
                throw new Exception($"{ClassName} : This filed only should provided when TIB is not set");

            return true;
        }
    }
}
