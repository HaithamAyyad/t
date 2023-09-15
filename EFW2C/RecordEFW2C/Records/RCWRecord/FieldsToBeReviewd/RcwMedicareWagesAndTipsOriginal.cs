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

    public class RcwMedicareWagesAndTipsOriginal : MoneyOriginal
    {
        public RcwMedicareWagesAndTipsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 331;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = GetEmploymentCode();
            var taxYear = _record.Manager.TaxYear;
            var localData = DataInRecordBuffer();

            if (employmentCode == EmploymentCodeEnum.H.ToString() && taxYear >= 1994)
            {
                var value = double.Parse(localData);
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                if (value != 0 || value < wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassName} : vlaue must be zero or equal or greater of MinHouseHold Covered Wages");
            }

            if (employmentCode == EmploymentCodeEnum.X.ToString() && taxYear >= 1983)
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : for year > 1983 and employees code 'X' field must be blank");
            }

            return true;
        }

    }
}
