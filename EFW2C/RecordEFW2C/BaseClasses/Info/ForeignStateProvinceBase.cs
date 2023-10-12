using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-3-1023
    //Reviewed by : 

    internal abstract class ForeignStateProvinceBase : FieldBase
    {
        public ForeignStateProvinceBase(RecordBase record, string data)
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
                var stateAbbreviationClassName = $"{_record.ClassName.Substring(0, 3)}StateAbbreviation";
                if (!IsFieldNullOrWhiteSpace(_record.GetField(stateAbbreviationClassName)))
                    throw new Exception($"{ClassDescription} can't be provided with {stateAbbreviationClassName} at the sametime");
            }

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
