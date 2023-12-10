using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Languages;
using EFW2C.Records;
using System;
using System.Linq;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RcwSocialSecurityNumberCorrect : SocialSecurityNumberCorrect
    {
        public RcwSocialSecurityNumberCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 12;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwSocialSecurityNumberCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (IsSameAsOriginalValue())
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MoneyOriginalMustNotSameAsCorrect));

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }
    }
}
