using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    internal class RcwSocialSecurityNumberOriginal : FieldOriginal
    {
        public RcwSocialSecurityNumberOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityNumberOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();
            var strValid1 = localData.Substring(0, 3);
            var strValid2 = localData.Substring(0, 1);
            if(strValid1 == "999" || strValid2 == "6")
                throw new Exception($"{ClassName} : SSN should not start with 999 or 6");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
