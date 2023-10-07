using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    internal class RcsStateCode : FieldBase
    {
        public RcsStateCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsStateCode(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if (!EnumHelper.IsValidStateCode(localData, true))
                throw new Exception($"{ClassDescription} {localData} is not a valid state code");

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
