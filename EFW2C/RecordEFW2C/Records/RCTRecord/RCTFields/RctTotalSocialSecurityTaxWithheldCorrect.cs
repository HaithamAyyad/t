using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RctTotalSocialSecurityTaxWithheldCorrect : SumFieldCorrect
    {
        public RctTotalSocialSecurityTaxWithheldCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 115;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalSocialSecurityTaxWithheldCorrect(record);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

             var localData = DataInRecordBuffer();

            var employmentCode = ((RctRecord)_record).Parent.GetEmploymentCode();

            if (employmentCode == EmploymentCodeEnum.Q.ToString() ||
                employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassDescription} : Must be blank if employment code '{employmentCode}'");
            }

            return true;
        }
    }
}

