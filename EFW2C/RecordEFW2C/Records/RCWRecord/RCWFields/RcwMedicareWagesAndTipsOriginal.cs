using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwMedicareWagesAndTipsOriginal : MoneyOriginal
    {
        public RcwMedicareWagesAndTipsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 331;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwMedicareWagesAndTipsOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = ((RcwRecord)_record).Parent.GetEmploymentCode();
            var taxYear = ((RcwRecord)_record).Parent.GetTaxYear();
            var localData = DataInRecordBuffer();

            if (employmentCode == EmploymentCodeEnum.H.ToString())
            {
                decimal.TryParse(localData, out var localValue);
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                if (localValue != 0 || localValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeZeroOrEqualToOrGreaterToHousHoldForYearIfCodeH));
            }

            if (employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankIfEmploymentCodeIs, employmentCode));
            }

            return true;
        }

    }
}
