﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by  : HSA on 9-1-2023
    //Reviewed by : 

    internal abstract class RecordIdentifierBase : FieldBase
    {
        public RecordIdentifierBase(RecordBase record,string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var uu = DataInRecordBuffer();

            if (DataInRecordBuffer() != _record.RecordName.ToUpper())
                throw new Exception($"{ClassDescription} Field must be {_record.RecordName.ToUpper()}");

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
