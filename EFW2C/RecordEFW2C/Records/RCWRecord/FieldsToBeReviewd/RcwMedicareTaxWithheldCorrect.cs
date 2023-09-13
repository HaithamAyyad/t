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

            var emoploymentCode = GetEmoploymentCode();
            if (emoploymentCode == EmploymentCodeEnum.X.ToString())
            {
                var localData = DataInRecordBuffer();

                if (Int32.Parse(localData) <= 0)
                    throw new Exception($"{ClassName} : since employment code is {emoploymentCode}, this feild must be greater than zero");
            }

            return true;
        }
    }
}
