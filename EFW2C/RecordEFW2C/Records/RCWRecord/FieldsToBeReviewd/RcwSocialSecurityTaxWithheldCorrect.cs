using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcwSocialSecurityTaxWithheldCorrect : MoneyCorrect
    {
        public RcwSocialSecurityTaxWithheldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 320;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = _record.Manager.TaxYear;

            if (taxYear < 1978)
                throw new Exception($"{ClassName} : this field is only vaild from 1978 ot later");

            var emoploymentCode = GetEmoploymentCode();
            if (emoploymentCode == EmploymentCodeEnum.Q.ToString() || emoploymentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception($"{ClassName} : since employment code is {emoploymentCode}, this feild must not be provided");

            if (taxYear == 2023)
            {
                var localData = DataInRecordBuffer();
                var value = double.Parse(localData);
                if(value > 9932.40)
                    throw new Exception($"{ClassName} since year 23 the value must mot exceed $9,932.40");

            }


            return true;
        }
    }
}

