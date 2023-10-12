using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-10-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsSupplementalData1 : FieldBase
    {
        public RcsSupplementalData1(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 499;
            _length = 150;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new RcsSupplementalData1(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

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
