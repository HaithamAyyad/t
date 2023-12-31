﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : 

    internal abstract class ZipCodeBase : FieldBase
    {
        public ZipCodeBase(RecordBase record, string data)
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

            /* removed as what AccuW2c2011 works
            if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                var stateAbbreviationClassName = $"{_record.ClassName.Substring(0, 3)}StateAbbreviation";

                if (IsFieldNullOrWhiteSpace(_record.GetField(stateAbbreviationClassName)))
                    throw new Exception($"{ClassDescription} must be empty since {stateAbbreviationClassName} is not provided");
            }*/

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
