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

    internal class RcwMedicareWagesAndTipsOriginal : MoneyOriginal
    {
        public RcwMedicareWagesAndTipsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 331;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwMedicareWagesAndTipsOriginal(record, _data);
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
                var value = double.Parse(localData);
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                if (value != 0 || value < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater than MinHouseHold Covered Wages");
            }

            if (employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank, because employment code is 'X'");
            }

            return true;
        }

    }
}