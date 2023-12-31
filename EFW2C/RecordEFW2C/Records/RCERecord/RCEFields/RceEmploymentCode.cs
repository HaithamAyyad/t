﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class RceEmploymentCode : FieldBase
    {
        public RceEmploymentCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 221;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            throw new Exception($"{ClassName} Field must be implement");

            //return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            throw new NotImplementedException();
            //return FieldTypeEnum.;
        }

        public override bool IsRequired()
        {
            throw new NotImplementedException();
        }
    }
}
