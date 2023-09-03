using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-3-2023
    //Reviewed by : 

    public class RcaPreparerCode : FieldBase
    {
        public RcaPreparerCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 315;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var code = DataInRecordBuffer();

            if (!IsPreparerCodeVaild(code))
                throw new Exception($"{ClassName}: {code} is not a valid preparer code.");

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
