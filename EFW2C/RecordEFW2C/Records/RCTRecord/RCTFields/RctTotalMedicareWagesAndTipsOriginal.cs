using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RctTotalMedicareWagesAndTipsOriginal : SumFieldOriginal
    {
        public RctTotalMedicareWagesAndTipsOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 130;
            _length = 15;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new RctTotalMedicareWagesAndTipsOriginal(record);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = ((RctRecord)_record).Parent.GetEmploymentCode();

            var taxYear = ((RctRecord) _record).Parent.GetTaxYear();

            var localData = DataInRecordBuffer();

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                double.TryParse(localData, out var localValue);

                if (localValue != 0 || localValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception($"{ClassDescription} : Must be zero or equal or greater than MinHouseHold Covered Wages if EmploymentCode is 'H'");
            }

            if (employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassDescription} : Must be blank if employment code is X");
            }

            return true;
        }
    }
}
