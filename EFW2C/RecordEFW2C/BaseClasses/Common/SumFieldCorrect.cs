using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal abstract class SumFieldCorrect : FieldCorrect
    {
        public SumFieldCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override void Write()
        {
            var fieldClassName = ClassName.Replace(Constants.TotalStr, "");

            var sum = 0;

            if (_record is RcwRecord rcwRecord)
                sum = rcwRecord.Parent.GetRcwFieldsSum(fieldClassName);

            if (_record is RcoRecord rcoRecord)
            {
                sum = rcoRecord.Parent.Parent.GetRcoFieldsSum(fieldClassName);
            }

            if (sum > 0)
            {
                _data = sum.ToString();
                base.Write();
            }
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var fieldClassName = ClassName.Replace(Constants.TotalStr, "");

            var sum = 0;

            if (_record is RcwRecord rcwRecord)
                sum = rcwRecord.Parent.GetRcwFieldsSum(fieldClassName);

            if (_record is RcoRecord rcoRecord)
            {
                sum = rcoRecord.Parent.Parent.GetRcoFieldsSum(fieldClassName);
            }

            var localData = DataInRecordBuffer();
            
            if (sum != Int32.Parse(localData))
                throw new Exception($"Total of {ClassName} is not correct");

            return true;
        }
    }
}
