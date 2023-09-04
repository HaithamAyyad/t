using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 
    
    public class ContactEMailInternetBase : FieldBase
    {
        public ContactEMailInternetBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var email = DataInRecordBuffer();

            if (string.IsNullOrWhiteSpace(email))
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
