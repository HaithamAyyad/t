﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 4-9-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceEstablishmentNumberCorrect : FieldCorrect
    {
        public RceEstablishmentNumberCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 39;
            _length = 4;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceEstablishmentNumberCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;
            
            if (IsSameAsOriginalValue())
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustEnterBlanksIfNoCorrections));

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
