using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-3-2023
    //Reviewed by : 

    public class RceTaxYear : FieldBase
    {
        public RceTaxYear(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 4;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
