using System;
using System.Linq;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-3-2023
    //Reviewed by : Hsa 10-10-203

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

        private bool IsValidResubWageFile(string data)
        {
            if (data.Length != _length)
                return false;

            return data.All(c => char.IsUpper(c) || char.IsDigit(c));
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if(!IsValidResubWageFile(localData))
                throw new Exception($"{ClassDescription} Is not Valid Resub Wage File");

            var rcaResubIndicator = _record.GetField(typeof(RcaResubIndicator).Name);

            if (rcaResubIndicator != null)
            {
                switch (rcaResubIndicator.DataInRecordBuffer())
                {
                    case "1":
                        if (string.IsNullOrWhiteSpace(localData))
                            throw new Exception($"{ClassDescription} if {rcaResubIndicator.ClassDescription} equals one, then this field can't be blank");
                        break;
                    case "0":
                        if (!string.IsNullOrWhiteSpace(Data))
                            throw new Exception($"{ClassDescription} if {rcaResubIndicator.ClassDescription} equals zero, then this field must be blank");
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
            {
                if (rcaResubIndicator.Data == ((int)ResubIndicatorCodeEnum.One).ToString())
                {
                    if (string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception($"{ClassDescription} if {rcaResubIndicator.ClassDescription} equals one, then this field can't be blank");
                }
            }
            return false;
        }
    }
}
