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

            var taxYear = _record.Manager.TaxYear;

            if (taxYear < 1983)
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank because tax year is less than 1983");
            }
            else
            {
                if (employmentCode != EmploymentCodeEnum.X.ToString())
                {
                    if (!string.IsNullOrWhiteSpace(localData))
                        throw new Exception($"{ClassName} : must be blank, because employment code is 'X' and year greater than 1983, then this feild ");
                }
                else
                {
                    if(taxYear >= 1991 && taxYear <= 1993)
                    {
                        var wageTax = WageTaxHelper.GetWageTax(taxYear);

                        var value = double.Parse(localData);
                        if(value > wageTax.Employee.MediCare.EmployeeMaxAnnualTax)
                            throw new Exception($"{ClassName} : since year is 1991-1993, Wage tax should not exceed Max Annual Tax");
                    }
                }
            }

            return true;
        }
    }
}
