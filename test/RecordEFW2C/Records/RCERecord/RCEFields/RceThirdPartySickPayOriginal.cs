using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class RceThirdPartySickPayOriginal : FieldBase
    {
        public RceThirdPartySickPayOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 223;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if(!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                if(!IsCorrectFieldProvided())
                    throw new Exception($"the correction filed for {ClassName} is not provided");
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
