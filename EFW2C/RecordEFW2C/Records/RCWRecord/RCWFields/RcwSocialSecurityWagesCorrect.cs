using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwSocialSecurityWagesCorrect : MoneyCorrect
    {
        public RcwSocialSecurityWagesCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 298;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityWagesCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = ((RcwRecord)_record).Parent.GetTaxYear();

            var employmentCode = ((RcwRecord)_record).Parent.GetEmploymentCode();
            if (employmentCode == EmploymentCodeEnum.Q.ToString() || employmentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankIfEmploymentCodeIs, employmentCode));

            var localData = DataInRecordBuffer();
            decimal.TryParse(localData, out var localValue);
            
            var wageTax = WageTaxHelper.GetWageTax(taxYear);

            var rcwSocialSecurityTipsCorrect = _record.GetField(typeof(RcwSocialSecurityTipsCorrect).Name);

            if (rcwSocialSecurityTipsCorrect == null)
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, "SocialSecurityTipsCorrect with correct data"));

            decimal.TryParse(rcwSocialSecurityTipsCorrect.DataInRecordBuffer(), out var socialSecurityTipsCorrectValue);

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                if (localValue != 0 || localValue + socialSecurityTipsCorrectValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeZeroOrEqualToOrGreaterToHousHoldForYearIfCodeH));
            }

            if (localValue + socialSecurityTipsCorrectValue > wageTax.SocialSecurity.MaxTaxedEarnings)
                throw new Exception(Error.Instance.GetError(ClassDescription, " plus SocialSecurityTipsCorrect ", Error.Instance.MustNotExceedSocialSecurityMaxTaxedEarnings));

            return true;
        }
    }
}

