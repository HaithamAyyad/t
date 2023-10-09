using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal abstract class MoneyOriginal : FieldOriginal
    {
        public MoneyOriginal(RecordBase record, string data)
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

            if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                if (IsCorrectMoneyFieldNullOrWhiteSpace())
                    throw new Exception($"{ClassDescription} correction field must be provided");
            }

            return true;
        }

        private bool IsCorrectMoneyFieldNullOrWhiteSpace()
        {
            if (!ClassName.Contains(Constants.OriginalStr))
                throw new Exception($"{ClassDescription} this function only used for {Constants.OriginalStr} class");

            var correctFieldName = ClassName.Replace(Constants.OriginalStr, Constants.CorrectStr);

            return IsFieldNullOrWhiteSpace(_record.GetField(correctFieldName));
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_RightJustify_Zero;
        }
    }
}