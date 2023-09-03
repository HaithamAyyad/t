using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-3-2023
    //Reviewed by : 

    public class RcaResubIndicator : FieldBase
    {
        public RcaResubIndicator(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 316;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var submitValue = DataInRecordBuffer();

            switch (submitValue)
            {
                case "0":
                    if (_record.Manager.IsSubmitter())
                        throw new Exception($"{ClassName} must be 1 because this file marked as resubmitted");
                    break;
                case "1":
                    if (!_record.Manager.IsSubmitter())
                        throw new Exception($"{ClassName} must be 0 because this file marked as not resubmitted");
                    break;
                default:
                    throw new Exception($"{ClassName}: the value is {submitValue} it must be either 1 or 0");
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
