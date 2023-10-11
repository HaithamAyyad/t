using System;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal abstract class FieldCorrect : FieldBase
    {
        public FieldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;

        }

        public override bool IsRequired()
        {
            return false;
        }

        protected bool IsOneCorrectMoneyFieldProvided()
        {
            foreach (var field in _record.Fields)
            {
                var typeOfClassField = Type.GetType(field.ToString())?.BaseType;
                while (typeOfClassField != null)
                {
                    if (typeOfClassField.ToString().Contains("MoneyCorrect"))
                        return true;

                    typeOfClassField = typeOfClassField.BaseType;
                }
            }

            return false;
        }

        protected bool IsSameAsOriginalValue()
        {
            if (!ClassName.Contains(Constants.CorrectStr))
                throw new Exception($"{ClassDescription} this function only used for {Constants.CorrectStr} class");

            var originalFieldName = ClassName.Replace(Constants.CorrectStr, Constants.OriginalStr);

            var originalField = _record.GetField(originalFieldName);
            if (!IsFieldNullOrWhiteSpace(originalField))
                return DataInRecordBuffer() == originalField.DataInRecordBuffer();

            return false;
        }

    }
}
