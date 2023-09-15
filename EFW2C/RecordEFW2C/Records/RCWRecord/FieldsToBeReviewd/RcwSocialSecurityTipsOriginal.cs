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

            var emoploymentCode = GetEmoploymentCode();
            var taxYear = _record.Manager.TaxYear;
            var localData = DataInRecordBuffer();

            if (emoploymentCode == EmploymentCodeEnum.H.ToString() && taxYear >= 1994)
            {
                var value = double.Parse(localData);
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                if (value != 0 || value < wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater of MinHouseHold Covered Wages");
            }
            
            return true;
        }
    }
}
