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

    internal class RcwMedicareWagesAndTipsCorrect : MoneyCorrect
    {
        public RcwMedicareWagesAndTipsCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 342;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwMedicareWagesAndTipsCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = ((RcwRecord)_record).Parent.GetTaxYear();
            var localData = DataInRecordBuffer();

            var employmentCode = ((RcwRecord)_record).Parent.GetEmploymentCode();

            if (employmentCode == EmploymentCodeEnum.X.ToString())
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankIfEmploymentCodeIs, employmentCode));
            }
            else
            {
                double.TryParse(localData, out var localValue);
                var wageTax = WageTaxHelper.GetWageTax(taxYear);

                if (employmentCode == EmploymentCodeEnum.H.ToString())
                {
                    if (localValue != 0 || localValue < wageTax.SocialSecurity.MinHouseHoldCoveredWages)
                        throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeZeroOrEqualToOrGreaterToHousHoldForYearIfCodeH));
                }
                else
                {
                    var rcwSocialSecurityTipsCorrect = _record.GetField(typeof(RcwSocialSecurityTipsCorrect).Name);

                    if (rcwSocialSecurityTipsCorrect == null)
                        throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, "SocialSecurityTipsCorrect with correct data"));

                    var rcwSocialSecurityWagesCorrect = _record.GetField(typeof(RcwSocialSecurityWagesCorrect).Name);
                    if (rcwSocialSecurityWagesCorrect == null)
                        throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, "SocialSecurityWagesCorrect with correct data"));

                    double.TryParse(rcwSocialSecurityTipsCorrect.DataInRecordBuffer(), out var rcwSocialSecurityTipsCorrectValue);
                    double.TryParse(rcwSocialSecurityWagesCorrect.DataInRecordBuffer(), out var rcwSocialSecurityWagesCorrectValue);

                    if (localValue < rcwSocialSecurityTipsCorrectValue + rcwSocialSecurityWagesCorrectValue)
                        throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeEqualOrGraterThanTheSumOf,
                            $"{rcwSocialSecurityWagesCorrect.ClassDescription} and {rcwSocialSecurityTipsCorrect.ClassDescription}"));
                }
                
            }

            return true;
        }
    }
}

