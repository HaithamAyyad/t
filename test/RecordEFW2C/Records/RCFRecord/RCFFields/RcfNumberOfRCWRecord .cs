using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class RcfNumberOfRCWRecord : FieldBase
    {
        public RcfNumberOfRCWRecord(RecordBase record)
            : base(record, record.Manager.GetRcwRecordsCount().ToString())
        {
            _pos = 3;
            _length = 9;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var RcwCount = _record.Manager.GetRcwRecordsCount();

            if (Int32.Parse(DataInRecordBuffer()) != RcwCount)
                throw new Exception($"{ClassName} number of RCW records is not correct");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_RightJustify_Zero;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
