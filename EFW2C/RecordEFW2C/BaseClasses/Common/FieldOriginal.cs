﻿using System;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-5-2023
    //Reviewed by : Hsa 10-12-2023
    
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

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                if (IsFieldNullOrWhiteSpace(GetCorrectField()))
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, "Correct field"));
            }

            return true;
        }

        public override bool IsRequired()
        {
            return false;
        }

        protected FieldBase GetCorrectField()
        {
            if (!ClassName.Contains(Constants.OriginalStr))
                throw new Exception(Error.Instance.GetInternalError(ClassDescription, Error.Instance.ThisFunctionOnlyUseFor, Constants.OriginalStr + "classes"));

            var correctFieldName = ClassName.Replace(Constants.OriginalStr, Constants.CorrectStr);

            return _record.GetField(correctFieldName);
        }
    }
}
