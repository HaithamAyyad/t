using System;
using EFW2C.Common.Enum;
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

            if (!(_data == "98" || _data == "99"))
                throw new Exception($"{ClassName} must be either 98 or 99");

            return true;
        }

        public bool OffShelfSoftware()
        {
            if (_data == "99")
                return true;

            return false;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_LeftJustify_Blank;
        }
    }
}
