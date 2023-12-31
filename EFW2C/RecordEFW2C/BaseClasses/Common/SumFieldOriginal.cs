﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-5-2023
    //Reviewed by : 

    internal abstract class SumFieldOriginal : MoneyOriginal
    {
        public SumFieldOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override void Write()
        {
            var fieldClassName = ClassName.ReplaceFirstOccurrence(Constants.TotalStr, "");

            decimal sum = 0;

            if (_record is RctRecord rctRecord)
            {
                fieldClassName = $"{RecordNameEnum.Rcw}{fieldClassName.Substring(3)}";
                sum = rctRecord.Parent.GetRcwFieldsSum(fieldClassName);
            }

            if (_record is RcuRecord rcuRecord)
            {
                fieldClassName = $"{RecordNameEnum.Rco}{fieldClassName.Substring(3)}";
                sum = rcuRecord.Parent.GetRcoFieldsSum(fieldClassName);
            }

            if (sum >= 0)
            {
                _data = sum.ToString();
                base.Write();
            }
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var fieldClassName = ClassName.ReplaceFirstOccurrence(Constants.TotalStr, "");

            decimal sum = 0;

            if (_record is RctRecord rctRecord)
            {
                fieldClassName = $"{RecordNameEnum.Rcw}{fieldClassName.Substring(3)}";
                sum = rctRecord.Parent.GetRcwFieldsSum(fieldClassName);
            }

            if (_record is RcuRecord rcuRecord)
            {
                fieldClassName = $"{RecordNameEnum.Rco}{fieldClassName.Substring(3)}";
                sum = rcuRecord.Parent.GetRcoFieldsSum(fieldClassName);
            }


            decimal.TryParse(DataInRecordBuffer(), out var localSum);

            if (sum != localSum)
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.TotalIsNotCorrect));

            return true;
        }
    }
}
