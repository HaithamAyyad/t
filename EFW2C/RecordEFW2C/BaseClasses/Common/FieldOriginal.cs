using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class FieldOriginal : FieldBase
    {
        public FieldOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if(!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                if(!IsCorrectionFieldProvided())
                    throw new Exception($"the correction filed for {ClassName} is not provided");
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        protected bool IsCorrectionFieldProvided()
        {
            return GetCorrectField() != null;
        }

        private FieldCorrect GetCorrectField()
        {
            if (!ClassName.Contains(Constants.OriginalStr))
                throw new Exception($"{ClassName} this function only used for {Constants.OriginalStr} class");

            var correctClassName = ClassName.Replace(Constants.OriginalStr, Constants.CorrectStr);

            return _record.GetFields(correctClassName) as FieldCorrect;
        }


        public override bool IsRequired()
        {
            return IsCorrectionFieldProvided();
        }
    }
}
