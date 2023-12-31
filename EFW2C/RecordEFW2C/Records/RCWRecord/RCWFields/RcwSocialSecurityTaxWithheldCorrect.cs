﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwSocialSecurityTaxWithheldCorrect : MoneyCorrect
    {
        public RcwSocialSecurityTaxWithheldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 320;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityTaxWithheldCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = ((RcwRecord)_record).Parent.GetTaxYear();

            var employmentCode = ((RcwRecord)_record).Parent.GetEmploymentCode();
            if (employmentCode == EmploymentCodeEnum.Q.ToString() || employmentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankIfEmploymentCodeIs, employmentCode));

            if (taxYear == 2023)
            {
                var localData = DataInRecordBuffer();
                decimal.TryParse(localData, out var localValue);
                if(localValue > 993240)
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.IfYear2023ValueMustNotExceed, "$9,932.40"));
            }

            return true;
        }
    }
}

