using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    internal abstract class StateAbbreviationBase : FieldBase
    {
        public StateAbbreviationBase(RecordBase record, string data)
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
                var foreignStateProvinceClassName = $"{_record.ClassName.Substring(0, 3)}ForeignStateProvince";
                if (!IsFieldNullOrWhiteSpace(_record.GetField(foreignStateProvinceClassName)))
                    throw new Exception($"{ClassName} can't provid this filed and {foreignStateProvinceClassName} at the sametime");
            }

            if (!EnumHelper.IsValidStateCode(DataInRecordBuffer()))
                throw new Exception($"{ClassName} State code is not valid");

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
