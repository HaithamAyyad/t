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

    public class RcwSocialSecurityWagesCorrect : MoneyCorrect
    {
        public RcwSocialSecurityWagesCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 298;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = _record.Manager.TaxYear;

            var employmentCode = GetEmploymentCode();
            if (employmentCode == EmploymentCodeEnum.Q.ToString() || employmentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception($"{ClassName} : since employment code is {employmentCode}, this feild must not be provided");

            var localData = DataInRecordBuffer();
            var value = double.Parse(localData);
            var wageTax = WageTaxHelper.GetWageTax(taxYear);

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                if (value != 0 || value < wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater than MinHouseHold Covered Wages ({wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages})");
            }

            if (value > wageTax.Employee.SocialSecurity.MaxTaxedEarnings)
                throw new Exception($"{ClassName} : vlaue must not exceed SocialSecurity MaxTaxedEarnings ({wageTax.Employee.SocialSecurity.MaxTaxedEarnings})");

            return true;
        }
    }
}

