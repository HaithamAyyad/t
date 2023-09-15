using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcwMedicareTaxWithheldOriginal : MoneyOriginal
    {
        public RcwMedicareTaxWithheldOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 353;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            var taxYear = _record.Manager.TaxYear;

            if (taxYear < 1983)
            {
                if (!string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : Tax year is less than 1983, then this feild must blank");
            }

            return true;
        }
    }
}
