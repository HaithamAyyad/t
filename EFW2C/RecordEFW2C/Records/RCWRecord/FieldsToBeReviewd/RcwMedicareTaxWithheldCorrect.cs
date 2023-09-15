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

    public class RcwMedicareTaxWithheldCorrect : MoneyCorrect
    {
        public RcwMedicareTaxWithheldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 364;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = GetEmploymentCode();

            var localData = DataInRecordBuffer();

            if (employmentCode != EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank, because employment code is 'X'");
            }

            return true;
        }
    }
}
