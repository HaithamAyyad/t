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

    public class RcwSocialSecurityTipsOriginal : MoneyOriginal
    {
        public RcwSocialSecurityTipsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 375;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = GetEmploymentCode();
            var taxYear = GetTaxYear();
            var localData = DataInRecordBuffer();

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                var value = double.Parse(localData);
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                var rcwSocialSecurityWagesOriginal = _record.GetField(typeof(RcwSocialSecurityWagesOriginal).Name);
                if (rcwSocialSecurityWagesOriginal == null)
                    throw new Exception($"{ClassName}: RcwSocialSecurityWagesOriginal must be provided");

                var rcwSocialSecurityWagesOriginalValue = double.Parse(rcwSocialSecurityWagesOriginal.DataInRecordBuffer());

                if (value != 0 || value + rcwSocialSecurityWagesOriginalValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater than MinHouseHold Covered Wages");
            }
            
            return true;
        }
    }
}
