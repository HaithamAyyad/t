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

    internal class RctTotalMedicareWagesAndTipsCorrect : SumFieldCorrect
    {
        public RctTotalMedicareWagesAndTipsCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 145;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalMedicareWagesAndTipsCorrect(record);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            var employmentCode = ((RctRecord)_record).Parent.GetEmploymentCode();

            var taxYear = ((RctRecord)_record).Parent.GetTaxYear();

            var rctSocialSecurityTipsCorrect = _record.GetField(typeof(RctTotalSocialSecurityTipsCorrect).Name);

            if (rctSocialSecurityTipsCorrect == null)
                throw new Exception($"{ClassDescription}: RctSocialSecurityTipsCorrect must be provided");

            var rctSocialSecurityWagesCorrect = _record.GetField(typeof(RctTotalSocialSecurityWagesCorrect).Name);
            if (rctSocialSecurityWagesCorrect == null)
                throw new Exception($"{ClassDescription}: RctSocialSecurityWagesCorrect must be provided");

            double.TryParse(rctSocialSecurityTipsCorrect.DataInRecordBuffer(), out var rctSocialSecurityTipsCorrectValue);
            double.TryParse(rctSocialSecurityWagesCorrect.DataInRecordBuffer(), out var rctSocialSecurityWagesCorrectValue);

            double.TryParse(localData, out var localValue);

            if (localValue < rctSocialSecurityTipsCorrectValue + rctSocialSecurityWagesCorrectValue)
                throw new Exception($"{ClassDescription} Value must be equal the sum of Social Security Tips and Social Security Wages");

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                if (localValue != 0 || localValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassDescription} : must be zero or equal to or greater than the annual Household minimum for the tax year being reported");
            }

            if (employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassDescription} : must be blank because employment code is X");
            }

            return true;
        }
    }
}

