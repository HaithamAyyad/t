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
    
    internal abstract class FieldOriginal : FieldBase
    {
        public FieldOriginal(RecordBase record, string data)
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

        private string GetCorrectClassDescription()
        {
            if (!ClassName.Contains(Constants.OriginalStr))
                throw new Exception($"{ClassDescription} this function only used for {Constants.OriginalStr} class");

            var correctFieldName = ClassName.Replace(Constants.OriginalStr, Constants.CorrectStr);

            return _record.HelperFieldsList.FirstOrDefault(x => x.ClassName == correctFieldName).ClassDescription;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                 if (IsCorrectFieldNullOrWhiteSpace())
                    throw new Exception($"{ClassDescription} {GetCorrectClassDescription()} Must not be blank. Otherwise enter blank in this field");
            }

            return true;
        }

        private bool IsCorrectFieldNullOrWhiteSpace()
        {
            if (!ClassName.Contains(Constants.OriginalStr))
                throw new Exception($"{ClassDescription} this function only used for {Constants.OriginalStr} class");

            var correctFieldName = ClassName.Replace(Constants.OriginalStr, Constants.CorrectStr);

            return IsFieldNullOrWhiteSpace(_record.GetField(correctFieldName));
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
