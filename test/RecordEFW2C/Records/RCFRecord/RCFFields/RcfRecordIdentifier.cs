using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Has 9-3-2023
    //Reviewed by : 

    public class RcfRecordIdentifier : FieldBase
    {
        public RcfRecordIdentifier(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (DataInRecordBuffer() != _record.RecordName)
                throw new Exception($"{ClassName} Field must be {_record.RecordName}");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
