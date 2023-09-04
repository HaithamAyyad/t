﻿using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-4-2023
    //Reviewed by : 

    public class RceKindOfEmployer : FieldBase
    {
        public RceKindOfEmployer(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 226;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();
            if (!IsKindOfEmployerValid(localData))
                throw new Exception($"{ClassName} : {localData} is not one of Employer Kind");

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
