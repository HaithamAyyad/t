﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    internal class RctTotalSocialSecurityTaxWithheldOriginal : SumFieldOriginal
    {
        public RctTotalSocialSecurityTaxWithheldOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 100;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalSocialSecurityTaxWithheldOriginal(record);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = ((RctRecord)_record).RceRecord.GetEmploymentCode();

            var localData = DataInRecordBuffer();

            if (employmentCode == EmploymentCodeEnum.Q.ToString() ||
                employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank for employment code X or Q");
            }

            return true;
        }
    }
}
