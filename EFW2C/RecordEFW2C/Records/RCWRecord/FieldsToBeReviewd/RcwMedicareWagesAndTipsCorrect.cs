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

    public class RcwMedicareWagesAndTipsCorrect : MoneyCorrect
    {
        public RcwMedicareWagesAndTipsCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 342;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var taxYear = _record.Manager.TaxYear;
            var localData = DataInRecordBuffer();

            if (taxYear < 1983)
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : Tax year is less than 1983, then this feild must blank");
            }
            else
            {
                var emoploymentCode = GetEmoploymentCode();

                if (emoploymentCode == EmploymentCodeEnum.X.ToString())
                {
                    if (!string.IsNullOrWhiteSpace(localData))
                        throw new Exception($"{ClassName} : Tax year is greater than 1983 and employee code is 'X', then this feild must blank");
                }
                else
                {
                    var value = double.Parse(localData);
                    var wageTax = WageTaxHelper.GetWageTax(taxYear);

                    if (emoploymentCode == EmploymentCodeEnum.H.ToString() && taxYear >= 1994)
                    {
                        if (value != 0 || value < wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages)
                            throw new Exception($"{ClassName} : vlaue must be zero or equal or greater of MinHouseHold Covered Wages ({wageTax.Employee.SocialSecurity.MinHouseHoldCoveredWages})");
                    }

                    if (emoploymentCode != EmploymentCodeEnum.H.ToString())
                    {
                        if (taxYear >= 1983 && taxYear <= 1993)
                        {
                            if (value > wageTax.Employee.MediCare.MaxTaxedEarnings)
                                throw new Exception($"{ClassName} : since year is between 1983- 1993, the value must not exceed MediCare MaxTaxedEarnings");
                        }

                        var rcwSocialSecurityTipsCorrect = _record.GetFields(typeof(RcwSocialSecurityTipsCorrect).Name);

                        if(rcwSocialSecurityTipsCorrect == null)
                            throw new Exception($"RcwSocialSecurityTipsCorrect : should be provided");

                        var rcwSocialSecurityWagesCorrect = _record.GetFields(typeof(RcwSocialSecurityWagesCorrect).Name);
                        if (rcwSocialSecurityWagesCorrect == null)
                            throw new Exception($"RcwSocialSecurityWagesCorrect : should be provided");

                        var rcwSocialSecurityTipsCorrectValue = double.Parse(rcwSocialSecurityTipsCorrect.DataInRecordBuffer());
                        var rcwSocialSecurityWagesCorrectValue = double.Parse(rcwSocialSecurityWagesCorrect.DataInRecordBuffer());

                        if (taxYear >= 1983 && taxYear < 1990)
                        {
                            if(value > 0)
                            {
                                if(value != rcwSocialSecurityTipsCorrectValue + rcwSocialSecurityWagesCorrectValue)
                                    throw new Exception($"Value should equal exacty the sum of Social Security Tips and Social Security Wages");
                            }
                        }

                        if (taxYear >= 1991)
                        {
                            if (value < rcwSocialSecurityTipsCorrectValue + rcwSocialSecurityWagesCorrectValue)
                                throw new Exception($"Value should equal or gratewr to the sum of Social Security Tips and Social Security Wages");
                        }
                    }
                }
            }

            return true;
        }
    }
}

