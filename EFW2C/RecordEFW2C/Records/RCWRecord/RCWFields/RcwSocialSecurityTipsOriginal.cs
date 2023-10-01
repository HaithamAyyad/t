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

    internal class RcwSocialSecurityTipsOriginal : MoneyOriginal
    {
        public RcwSocialSecurityTipsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 375;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityTipsOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = ((RcwRecord)_record).Parent.GetEmploymentCode();
            var taxYear = ((RcwRecord)_record).Parent.GetTaxYear();
            var localData = DataInRecordBuffer();

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                double.TryParse(localData, out var localValue);
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                var rcwSocialSecurityWagesOriginal = _record.GetField(typeof(RcwSocialSecurityWagesOriginal).Name);
                if (rcwSocialSecurityWagesOriginal == null)
                    throw new Exception($"{ClassName}: RcwSocialSecurityWagesOriginal must be provided");

                double.TryParse(rcwSocialSecurityWagesOriginal.DataInRecordBuffer(), out var rcwSocialSecurityWagesOriginalValue);

                if (localValue != 0 || localValue + rcwSocialSecurityWagesOriginalValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater than MinHouseHold Covered Wages");
            }
            
            return true;
        }
    }
}
