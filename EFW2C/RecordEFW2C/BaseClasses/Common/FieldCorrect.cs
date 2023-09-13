using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class FieldCorrect : FieldBase
    {
        public bool IgnoreOriginalField { get; set; }
        public FieldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if(!IgnoreOriginalField && !IsOriginalNullOrWhiteSpace())
            {
                if(string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                    throw new Exception($"{ClassName}: since you provide the original field then must fill {ClassName}");
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return !IsOriginalNullOrWhiteSpace();
        }

        protected bool IsOriginalNullOrWhiteSpace()
        {
            if (!ClassName.Contains(Constants.CorrectStr))
                throw new Exception($"{ClassName} this function only used for {Constants.CorrectStr} class");

            var originalName = ClassName.Replace(Constants.CorrectStr, Constants.OriginalStr);

            var originalfield = _record.GetFields(originalName);

            return originalfield == null ? true : string.IsNullOrWhiteSpace(originalfield.DataInRecordBuffer());
        }

        protected bool IsOneCorrectMoneyFieldProvided()
        {
            foreach (var field in _record.Fields)
            {
                var typeOfClassFiled = Type.GetType(field.ToString())?.BaseType;
                while (typeOfClassFiled != null)
                {
                    if (typeOfClassFiled.ToString().Contains("MoneyCorrect"))
                        return true;

                    typeOfClassFiled = typeOfClassFiled.BaseType;
                }
            }

            return false;
        }
    }
}
