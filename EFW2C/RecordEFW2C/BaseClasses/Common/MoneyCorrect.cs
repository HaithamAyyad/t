using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal abstract class MoneyCorrect : FieldCorrect
    {
        public MoneyCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
            _fieldFormat = FieldFormat.Money;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!IsOriginalMoneyFieldNullOrWhiteSpace())
            {
                if (string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                    throw new Exception($"{ClassDescription}: since you provide the original field then must fill {ClassDescription}");
            }

            if (IsSameAsOriginalValue())
                throw new Exception($"{ClassDescription} the Original reported money filed must not be the same as the correct money field");

            return true;
        }

        private bool IsOriginalMoneyFieldNullOrWhiteSpace()
        {
            if (!ClassName.Contains(Constants.CorrectStr))
                throw new Exception($"{ClassDescription} this function only used for {Constants.CorrectStr} class");

            var originalFieldName = ClassName.Replace(Constants.CorrectStr, Constants.OriginalStr);

            return IsFieldNullOrWhiteSpace(_record.GetField(originalFieldName));
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_RightJustify_Zero;
        }
    }
}
