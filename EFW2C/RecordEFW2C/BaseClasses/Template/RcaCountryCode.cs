using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaCountryCode : FieldBase
    {
        public RcaCountryCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 209;
            _length = 2;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var str = new string(_record.RecordBuffer, _pos, _length);

            if(!IsCountryCodeValid(str))
                 throw new Exception($"{ClassName} country code is not correct");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }
    }
}
