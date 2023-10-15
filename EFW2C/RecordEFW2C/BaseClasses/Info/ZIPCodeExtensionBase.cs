using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : 

    internal abstract class ZipCodeExtensionBase : FieldBase
    {
        public ZipCodeExtensionBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                var zipCodeClassName = $"{_record.ClassName.Substring(0, 3)}ZipCode";
                if (IsFieldNullOrWhiteSpace(_record.GetField(zipCodeClassName)))
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, $"{zipCodeClassName.Substring(3)}"));
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
