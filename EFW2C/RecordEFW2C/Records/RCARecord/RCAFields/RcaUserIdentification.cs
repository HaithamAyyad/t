using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : HSA 10-10-2023

    internal class RcaUserIdentification : FieldBase
    {
        public RcaUserIdentification(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 12;
            _length = 8;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaUserIdentification(record, _data);
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
