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

    public class RctTotalMedicareWagesAndTipsCorrect : SumFieldCorrect
    {
        public RctTotalMedicareWagesAndTipsCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 145;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            var employmentCode = GetEmploymentCode();

            var taxYear = GetTaxYear();

            var value = double.Parse(localData);

            var rctSocialSecurityTipsCorrect = _record.GetField(typeof(RctTotalSocialSecurityTipsCorrect).Name);

            if (rctSocialSecurityTipsCorrect == null)
                throw new Exception($"{ClassName}: RctSocialSecurityTipsCorrect must be provided");

            var rctSocialSecurityWagesCorrect = _record.GetField(typeof(RctTotalSocialSecurityWagesCorrect).Name);
            if (rctSocialSecurityWagesCorrect == null)
                throw new Exception($"{ClassName}: RctSocialSecurityWagesCorrect must be provided");

            var rctSocialSecurityTipsCorrectValue = double.Parse(rctSocialSecurityTipsCorrect.DataInRecordBuffer());
            var rctSocialSecurityWagesCorrectValue = double.Parse(rctSocialSecurityWagesCorrect.DataInRecordBuffer());

            if (value < rctSocialSecurityTipsCorrectValue + rctSocialSecurityWagesCorrectValue)
                throw new Exception($"Value must be equal the sum of Social Security Tips and Social Security Wages");

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                if (value != 0 || value < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : must be zero or equal to or greater than the annual Household minimum for the tax year being reported");
            }

            if (employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank because employment code is X");
            }

            return true;
        }
    }
}

