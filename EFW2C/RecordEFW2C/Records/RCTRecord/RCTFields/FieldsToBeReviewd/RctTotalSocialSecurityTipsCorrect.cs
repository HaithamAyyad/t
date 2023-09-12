using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RctTotalSocialSecurityTipsCorrect : SumFieldCorrect
    {
        public RctTotalSocialSecurityTipsCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 205;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var precedeRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.Rce.ToString());

            if (precedeRce == null)
                throw new Exception($"{ClassName} : RCE record is not provided");

            var employmentCodeField = precedeRce.GetFields(typeof(RceEmploymentCodeCorrect).Name);

            var taxYear = _record.Manager.TaxYear;

            var localData = DataInRecordBuffer();

            var employmentCode = employmentCodeField.DataInRecordBuffer();

            if (employmentCodeField != null)
            {
                if ((employmentCode == "Q" || employmentCode == "X") && !string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank");

                if (employmentCode == "H" && taxYear >= 1994)
                {
                    if (!_record.Manager.WageTaxTable.ContainsKey(taxYear))
                        throw new Exception($"{ClassName} : Wages and Tax table missing year {taxYear} info ");

                    double.TryParse(localData, out var value);

                    if (!(value == 0 || value >= _record.Manager.WageTaxTable[taxYear].Employee.SocialSecurity.MinHouseHoldCoveredWages))
                        throw new Exception($"{ClassName} : must be zero or equal to or greater than the annual Household minimum for the tax year being reported");
                }
            }

            return true;
        }
    }
}

