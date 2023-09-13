using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class MoneyCorrect : FieldCorrect
    {
        public MoneyCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_RightJustify_Zero;
        }

        protected string GetEmoploymentCode()
        {
            var precedRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.Rce.ToString());

            if (precedRce == null)
                throw new Exception($"{ClassName} : RCE record is not provided");

            var employmentCodeField = precedRce.GetFields(typeof(RceEmploymentCodeCorrect).Name);
            return employmentCodeField?.DataInRecordBuffer();
        }
    }
}
