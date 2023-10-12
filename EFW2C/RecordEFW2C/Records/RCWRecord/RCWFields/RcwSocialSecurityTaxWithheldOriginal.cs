using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwSocialSecurityTaxWithheldOriginal : MoneyOriginal
    {
        public RcwSocialSecurityTaxWithheldOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 309;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityTaxWithheldOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = ((RcwRecord)_record).Parent.GetEmploymentCode();
            if (employmentCode == EmploymentCodeEnum.Q.ToString() || employmentCode == EmploymentCodeEnum.X.ToString())
                throw new Exception($"{ClassDescription} : Must be balnk if EmploymentCode is {employmentCode}");

            return true;
        }
    }
}
