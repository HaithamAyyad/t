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

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = _record.Manager.TaxYear;

            if (taxYear < 1978)
                throw new Exception($"{ClassName} : this field is only vaild from 1978 ot later");

            var emoploymentCode = GetEmoploymentCode();
            if (emoploymentCode == EmploymentCodeEnum.Q.ToString() || emoploymentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception($"{ClassName} : since employment code is {emoploymentCode}, this feild must not be provided");

            var localData = DataInRecordBuffer();
            var value = double.Parse(localData);
            var wageTax = WageTaxHelper.GetWageTax(taxYear);

            if (emoploymentCode == EmploymentCodeEnum.H.ToString() && taxYear >= 1994)
            {
                if (value != 0 || value < wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater of MinHouseHold Covered Wages ({wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages})");
            }

            if(value > wageTax.Employee.SocialSecurity.MaxTaxedEarnings)
                throw new Exception($"{ClassName} : vlaue must exceed SocialSecurity MaxTaxedEarnings ({wageTax.Employee.SocialSecurity.MaxTaxedEarnings})");

            return true;
        }
    }
}
