using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
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

            var localData = DataInRecordBuffer();

            if (_record.Manager.TaxYear < 1983)
            {
                if(!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : Tax year is less than 1983, then this feild must blank");
            }

            var emoploymentCode = GetEmoploymentCode();
            if (emoploymentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : Employment code is 'X', then this feild must blank");
            }


            if (emoploymentCode != EmploymentCodeEnum.X.ToString())
            {

            }

            return true;
        }
    }
}
