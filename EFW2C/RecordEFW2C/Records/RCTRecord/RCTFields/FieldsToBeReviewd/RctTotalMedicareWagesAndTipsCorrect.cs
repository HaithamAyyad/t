﻿using System;
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

            var employmentCode = GetEmploymentCode();

            var taxYear = _record.Manager.TaxYear;

            var localData = DataInRecordBuffer();

            var RctTotalSocialSecurityTipsCorrectField = _record.GetField(typeof(RctTotalSocialSecurityTipsCorrect).Name);
            var RctTotalSocialSecurityWagesCorrectField = _record.GetField(typeof(RctTotalSocialSecurityWagesCorrect).Name);

            if (RctTotalSocialSecurityTipsCorrectField != null && RctTotalSocialSecurityWagesCorrectField != null)
            {
                //to continue HSA7
            }

            if (employmentCode == EmploymentCodeEnum.H.ToString() && taxYear >= 1994)
            {
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                double.TryParse(localData, out var value);

                if (!(value == 0 || value >= wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages))
                    throw new Exception($"{ClassName} : must be zero or equal to or greater than the annual Household minimum for the tax year being reported");
            }

            if (employmentCode == EmploymentCodeEnum.X.ToString() && taxYear >= 1983)
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank because tax year is greater than 1983 and employment code is X");
            }


            return true;
        }
    }
}

