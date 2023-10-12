using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-12-2023

    internal abstract class DeliveryAddressBase : FieldBase
    {
        public DeliveryAddressBase(RecordBase record, string data)
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

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_Address_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
