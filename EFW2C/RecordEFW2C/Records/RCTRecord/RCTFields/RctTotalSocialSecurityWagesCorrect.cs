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

    internal class RctTotalSocialSecurityWagesCorrect : SumFieldCorrect
    {
        public RctTotalSocialSecurityWagesCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 85;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalSocialSecurityWagesCorrect(record);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = ((RctRecord)_record).Parent.GetTaxYear();

            var localData = DataInRecordBuffer();

            var employmentCode = ((RctRecord)_record).Parent.GetEmploymentCode();

            if (employmentCode == EmploymentCodeEnum.Q.ToString() ||
                employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassDescription} : must be blank for employment code X or Q");
            }

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                double.TryParse(localData, out var localValue);

                if (localValue != 0 || localValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassDescription} : must be zero or equal to or greater than the annual Household minimum for the tax year being reported");
            }

            return true;
        }
    }
}

