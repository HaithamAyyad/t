using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-3-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaPreparerCode : FieldBase
    {
        public RcaPreparerCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 315;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaPreparerCode(record, _data);
        }


        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var code = DataInRecordBuffer();

            if (!EnumHelper.IsPreparerCodeVaild(code))
                throw new Exception($"{ClassDescription} Preparer code {code} is not valid");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            // we set this true , while testing AccuW2c, it is not mentioned in spec.
            return true;
        }
    }
}
