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

    internal class RcwSocialSecurityTipsCorrect : MoneyCorrect
    {
        public RcwSocialSecurityTipsCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 386;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityTipsCorrect(record, _data);
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

            var rcwSocialSecurityWagesCorrect = _record.GetField(typeof(RcwSocialSecurityWagesCorrect).Name);
            if (rcwSocialSecurityWagesCorrect == null)
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, "SocialSecurityWagesCorrect with correct data"));

            decimal.TryParse(rcwSocialSecurityWagesCorrect.DataInRecordBuffer(), out var rcwSocialSecurityWagesCorrectValue);

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                if (localValue != 0 || localValue + rcwSocialSecurityWagesCorrectValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeZeroOrEqualToOrGreaterToHousHoldForYearIfCodeH));
            }

            if (localValue + rcwSocialSecurityWagesCorrectValue > wageTax.SocialSecurity.MaxTaxedEarnings)
                throw new Exception(Error.Instance.GetError(ClassDescription, " plus SocialSecurityWagesCorrect ", Error.Instance.MustNotExceedSocialSecurityMaxTaxedEarnings));

            return true;
        }
    }
}
