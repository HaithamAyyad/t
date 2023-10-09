using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Records;
using System;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

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

            var lacalData = DataInRecordBuffer();

            if(lacalData.Substring(0, 3) == Constants.Str_666 || lacalData.Substring(0, 1) == Constants.Str_9)
                throw new Exception($"{ClassDescription}: Social Security Number, should not start with '666' or '9'");

            if (_record.GetField(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) == null &&
                _record.GetField(typeof(RcwThirdPartySickPayndicatorCorrect).Name) == null  &&
                _record.GetField(typeof(RcwRetirementPlanIndicatorCorrect).Name) == null    &&
                !IsOneCorrectMoneyFieldProvided())
               throw new Exception($"{ClassDescription}: you must provoide at least one indecator or the SSN original field or at least one correct money field");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            if (base.IsRequired())
                return true;

            if (_record.GetField(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) != null
                || _record.GetField(typeof(RcwThirdPartySickPayndicatorCorrect).Name) != null
                || _record.GetField(typeof(RcwRetirementPlanIndicatorCorrect).Name) !=null)
                return true;

            if (IsOneCorrectMoneyFieldProvided())
                return true;

            return false;
        }
    }
}
