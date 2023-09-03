using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 
    
    public class ContactEMailInternet : FieldBase
    {
        public ContactEMailInternet(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 261;
            _length = 40;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var email = new string(_record.RecordBuffer, _pos, _length);

            if (string.IsNullOrEmpty(email))
                throw new Exception($"{ClassName} email is empty");

            if (!VerifyEmail(email))
                throw new Exception($"{ClassName} email is not correct");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.CaseSensitive_LeftJustify;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
