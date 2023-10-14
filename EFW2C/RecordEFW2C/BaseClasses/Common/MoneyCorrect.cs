using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-5-2023
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

            var originalField = GetOriginalField();
            if (!IsFieldNullOrWhiteSpace(originalField))
            {
                if (string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                    throw new Exception($"{ClassDescription}: Must not be blank Otherwise enter blank in original field");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                    throw new Exception($"{ClassDescription}: Must be blank or fill original field");
            }

            if (IsSameAsOriginalValue())
                throw new Exception($"{ClassDescription} the Original reported money filed must not be the same as the correct money field");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_RightJustify_Zero;
        }
    }
}
