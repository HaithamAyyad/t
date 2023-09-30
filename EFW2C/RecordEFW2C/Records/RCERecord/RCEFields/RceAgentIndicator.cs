﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-4-2023
    //Reviewed by : 

    internal class RceAgentIndicator : FieldBase
    {
        public RceAgentIndicator(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 25;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceAgentIndicator(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if (!string.IsNullOrWhiteSpace(localData))
            {
                if (!EnumHelper.IsAgentIndicatorValid(localData, true))
                    throw new Exception($"{ClassName} {localData} is not Valid Agent Indicator");
            }

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
