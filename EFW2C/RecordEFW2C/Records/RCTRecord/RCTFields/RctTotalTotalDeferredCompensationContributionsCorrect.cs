using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RctTotalTotalDeferredCompensationContributionsCorrect : SumFieldCorrect
    {
        public RctTotalTotalDeferredCompensationContributionsCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 445;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = ((RctRecord)_record).Parent.GetTaxYear();

            if (taxYear < 1987 || taxYear > 2005)
                throw new Exception($"{ClassDescription} : This field only for tax year 1987 to 2005");

            return true;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalTotalDeferredCompensationContributionsCorrect(record);
        }
    }
}
