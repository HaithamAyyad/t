using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2013
    //Reviewed by : 

    internal class RceEmployerName : FieldBase
    {
        public RceEmployerName(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 43;
            _length = 57;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new RceEmployerName(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
