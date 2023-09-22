﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-10-2023
    //Reviewed by : 

    public class RcsSupplementalData2 : FieldBase
    {
        public RcsSupplementalData2(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 649;
            _length = 150;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsSupplementalData2(record, _data);
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
