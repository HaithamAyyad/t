using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
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

        public override void Write()
        {
            base.Write();

            var socialSecurityNumberOriginalField = GetOriginalField();
            if(socialSecurityNumberOriginalField == null )
            {
                var socialSecurityNumberOriginalName = typeof(RcwSocialSecurityNumberOriginal).Name;

                socialSecurityNumberOriginalField = _record.HelperFieldsList.FirstOrDefault(item => item.ClassName == socialSecurityNumberOriginalName);

                socialSecurityNumberOriginalField = socialSecurityNumberOriginalField.Clone(_record, Constants.SNN_Empty);
                socialSecurityNumberOriginalField.Write();
            }

        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var lacalData = DataInRecordBuffer();

            if (lacalData.Substring(0, 3) == Constants.Str_666 || lacalData.Substring(0, 1) == Constants.Str_9)
                throw new Exception($"{ClassDescription}: May not start with '666' or '9'");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }
    }
}
