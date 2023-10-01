using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-3-2023
    //Reviewed by : 

    internal class RcaResubIndicator : FieldBase
    {
        public RcaResubIndicator(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 316;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaResubIndicator(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if(!EnumHelper.IsResubIndicatorCodeValid(localData, true))
                throw new Exception($"{ClassName} must be ethier 0 or 1");

            switch (localData)
            {
                case "0":
                    if (_record.Manager.IsSubmitter)
                        throw new Exception($"{ClassName} must be 1 because this file marked as resubmitted");
                    break;
                case "1":
                    if (!_record.Manager.IsSubmitter)
                        throw new Exception($"{ClassName} must be 0 because this file marked as not resubmitted");
                    break;
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
