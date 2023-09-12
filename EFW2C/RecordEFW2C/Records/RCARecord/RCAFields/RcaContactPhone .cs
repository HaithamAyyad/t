using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2013
    //Reviewed by : 

    public class RcaContactPhone : FieldBase
    {
        public RcaContactPhone(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 238;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
