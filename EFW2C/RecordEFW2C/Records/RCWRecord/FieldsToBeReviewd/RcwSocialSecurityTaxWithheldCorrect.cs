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

            var precedRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.Rce.ToString());

            if (precedRce == null)
                throw new Exception($"{ClassName} : RCE record is not provided");

            var employmentCodeField = precedRce.GetFields(typeof(RceEmploymentCodeCorrect).Name);
            if (employmentCodeField != null)
            {
                var employmentCodeData = employmentCodeField.DataInRecordBuffer();
                if (employmentCodeData == EmploymentCodeEnum.Q.ToString())
                {
                    throw new Exception($"{ClassName} : since employment code is Q, this feild must not be provided");
                }
            }

            return true;
        }
    }
}

