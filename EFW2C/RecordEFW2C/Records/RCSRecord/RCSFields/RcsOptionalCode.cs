using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsOptionalCode : FieldBase
    {
        public RcsOptionalCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 253;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsOptionalCode(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_record.Manager.IsUnEmployment && !string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                throw new Exception($"{ClassDescription} : This field only applies to unemployment reporting");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
