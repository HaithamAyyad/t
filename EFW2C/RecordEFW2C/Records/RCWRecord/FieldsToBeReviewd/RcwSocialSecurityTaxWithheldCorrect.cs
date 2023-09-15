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

            var employmentCode = GetEmploymentCode();
            if (employmentCode == EmploymentCodeEnum.Q.ToString() || employmentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception($"{ClassName} : since employment code is {employmentCode}, this feild must not be provided");

            if (taxYear == 2023)
            {
                var localData = DataInRecordBuffer();
                var value = double.Parse(localData);
                if(value > 9932.40)
                    throw new Exception($"{ClassName} since year is 2023 the value must not exceed $9,932.40");
            }


            return true;
        }
    }
}

