using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class RceEmploymentCodeCorrect : FieldCorrect
    {
        public RceEmploymentCodeCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 222;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceEmploymentCodeCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!IsOriginalNullOrWhiteSpace())
            {
                var employmentCode = DataInRecordBuffer();

                if (string.IsNullOrWhiteSpace(employmentCode))
                    throw new Exception($"{ClassName} cant be empty since original field is provided");
                
                if (!EnumHelper.IsEmploymentCodeValid(employmentCode))
                    throw new Exception($"{ClassName}: {employmentCode} is not a valid Employment Code");
            }

            return true;
        }
    }
}
