using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : 
    
    internal abstract class ContactEMailInternetBase : FieldBase
    {
        public ContactEMailInternetBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
            _fieldFormat = FieldFormat.Email;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var email = DataInRecordBuffer();

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.EmailIsEmpty));

            if (!VerifyEmail(email))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.EmailIsNotCorrect));

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.CaseSensitive_LeftJustify;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
