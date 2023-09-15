﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcwSocialSecurityTaxWithheldOriginal : MoneyOriginal
    {
        public RcwSocialSecurityTaxWithheldOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 309;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = GetEmploymentCode();
            if (employmentCode == EmploymentCodeEnum.Q.ToString() || employmentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception($"{ClassName} : since employment code is {employmentCode}, this feild must not be provided");

            return true;
        }
    }
}
