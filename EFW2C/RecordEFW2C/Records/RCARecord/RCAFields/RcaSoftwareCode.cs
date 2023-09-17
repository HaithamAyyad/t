using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class RcaSoftwareCode : FieldBase
    {
        public RcaSoftwareCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 29;
            _length = 2;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if (!(localData == ((int)SoftwareCodeEnum.Code_98).ToString() || localData == ((int)SoftwareCodeEnum.Code_99).ToString()))
                throw new Exception($"{ClassName} must be either 98 or 99");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
