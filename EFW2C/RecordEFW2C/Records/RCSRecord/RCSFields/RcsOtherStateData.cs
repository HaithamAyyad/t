﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsOtherStateData : FieldBase
    {
        public RcsOtherStateData(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 441;
            _length = 20;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsOtherStateData(record, _data);
        }

        //Applies to Income Tax reporting.
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
