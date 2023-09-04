using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2013
    //Reviewed by : 

    public class ContactPhoneBase : FieldBase
    {
        public ContactPhoneBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
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
