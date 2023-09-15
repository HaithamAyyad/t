using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcwTotalDeferredCompensationContributionsCorrect : MoneyCorrect
    {
        public RcwTotalDeferredCompensationContributionsCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 562;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_record.Manager.IsTIB)
                throw new Exception($"{ClassName} : This filed only should provided whe TIB is not set");

            var taxYear = _record.Manager.TaxYear;

            if(!(taxYear >= 1987 && taxYear <= 2005))
                throw new Exception($"{ClassName} : This filed vaild between 1987-2005");

            return true;
        }
    }
}

