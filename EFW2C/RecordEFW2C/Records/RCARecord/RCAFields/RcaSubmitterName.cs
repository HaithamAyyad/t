using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-1-2023
    //Reviewed by : 

    internal class RcaSubmitterName : FieldBase
    {
        public RcaSubmitterName(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 31;
            _length = 57;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaSubmitterName(record, _data);
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
