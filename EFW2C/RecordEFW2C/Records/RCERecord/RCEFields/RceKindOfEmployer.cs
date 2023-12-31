﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-4-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceKindOfEmployer : FieldBase
    {
        public RceKindOfEmployer(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 226;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceKindOfEmployer(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();
            if (!EnumHelper.IsKindOfEmployerValid(localData))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.IsNotVaildKindOfEmployer));

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
