﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hSa 9-3-2023
    //Reviewed by : 

    internal class RcaResubWageFile : FieldBase
    {
        public RcaResubWageFile(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 317;
            _length = 6;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaResubWageFile(record, _data);
        }

        public override void Write()
        {
            var rcaResubIndicator = _record.GetField(typeof(RcaResubIndicator).Name);

            if (rcaResubIndicator != null && rcaResubIndicator.DataInRecordBuffer() == "1")
                base.Write();
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var rcaResubIndicator = _record.GetField(typeof(RcaResubIndicator).Name);

            if (rcaResubIndicator != null)
            {
                var localData = DataInRecordBuffer();
 
                switch (rcaResubIndicator.DataInRecordBuffer())
                {
                    case "1":
                        if (string.IsNullOrWhiteSpace(localData))
                            throw new Exception($"{ClassDescription} cannot be empty because {rcaResubIndicator.ClassName} is set to 1");
                        break;

                    case "0":
                        if (!string.IsNullOrWhiteSpace(Data))
                            throw new Exception($"{ClassDescription} must be empty because {rcaResubIndicator.ClassName} is set to 0");
                        break;
                }
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            var rcaResubIndicator = _record.GetField(typeof(RcaResubIndicator).Name);
            if (!IsFieldNullOrWhiteSpace(rcaResubIndicator))
                return (rcaResubIndicator.DataInRecordBuffer()) == ((int)ResubIndicatorCodeEnum.One).ToString();

            return false;
        }
    }
}
