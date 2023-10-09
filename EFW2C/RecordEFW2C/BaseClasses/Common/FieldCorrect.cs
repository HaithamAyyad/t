﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal abstract class FieldCorrect : FieldBase
    {
        public FieldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        protected bool IsOneCorrectMoneyFieldProvided()
        {
            foreach (var field in _record.Fields)
            {
                var typeOfClassField = Type.GetType(field.ToString())?.BaseType;
                while (typeOfClassField != null)
                {
                    if (typeOfClassField.ToString().Contains("MoneyCorrect"))
                        return true;

                    typeOfClassField = typeOfClassField.BaseType;
                }
            }

            return false;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
