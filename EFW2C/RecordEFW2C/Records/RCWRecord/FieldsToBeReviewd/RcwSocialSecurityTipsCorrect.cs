using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcwSocialSecurityTipsCorrect : MoneyCorrect
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

            var taxYear = GetTaxYear();

            var employmentCode = GetEmploymentCode();
            if (employmentCode == EmploymentCodeEnum.Q.ToString() || employmentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception($"{ClassName} : since employment code is {employmentCode}, this feild must not be provided");

            var localData = DataInRecordBuffer();
            var value = double.Parse(localData);
            var wageTax = WageTaxHelper.GetWageTax(taxYear);

            var rcwSocialSecurityWagesCorrect = _record.GetField(typeof(RcwSocialSecurityWagesCorrect).Name);
            if (rcwSocialSecurityWagesCorrect == null)
                throw new Exception($"{ClassName}: RcwSocialSecurityWagesCorrect must be provided");

            var rcwSocialSecurityWagesCorrectValue = double.Parse(rcwSocialSecurityWagesCorrect.DataInRecordBuffer());

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                if (value != 0 || value + rcwSocialSecurityWagesCorrectValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater than MinHouseHold Covered Wages ({wageTax.SocialSecurity.MinHouseHoldCoveredWages})");
            }

            if (value + rcwSocialSecurityWagesCorrectValue > wageTax.SocialSecurity.MaxTaxedEarnings)
                throw new Exception($"{ClassName} : vlaue must not exceed SocialSecurity MaxTaxedEarnings");

            return true;
        }
    }
}
