﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class RceEmploymentCodeCorrect : FieldBase
    {
        public RceEmploymentCodeCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 222;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!IsOriginalNullOrWhiteSpace())
            {
                if (string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                    throw new Exception($"{ClassName} cant be empty since original field is provided");

                var employmentCode = DataInRecordBuffer();
                if (!EnumHelper.IsEmploymentCodeValid(employmentCode))
                    throw new Exception($"{ClassName}: {employmentCode} is not valid Employment Code");
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return IsOriginalNullOrWhiteSpace();
        }
    }
}
