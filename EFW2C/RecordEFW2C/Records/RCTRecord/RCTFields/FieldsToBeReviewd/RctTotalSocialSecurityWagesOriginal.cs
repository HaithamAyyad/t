﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;
using test.RecordEFW2C.Common;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RctTotalSocialSecurityWagesOriginal : SumFieldOriginal
    {
        public RctTotalSocialSecurityWagesOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 70;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = GetEmploymentCode();

            var taxYear = _record.Manager.TaxYear;

            var localData = DataInRecordBuffer();

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                double.TryParse(localData, out var value);

                if (value != 0 || value < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : must be zero or equal to or greater than the annual Household minimum for the tax year being reported");
            }

            return true;
        }
    }
}
