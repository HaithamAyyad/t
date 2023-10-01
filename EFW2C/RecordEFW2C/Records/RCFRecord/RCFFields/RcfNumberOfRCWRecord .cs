using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    internal class RcfNumberOfRCWRecord : FieldBase
    {
        public RcfNumberOfRCWRecord(RecordBase record)
            : base(record, "0")
        {
            _pos = 3;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcfNumberOfRCWRecord(record);
        }

        public override void Write()
        {
            _data = _record.Manager.GetRcwRecordsCount().ToString();
            base.Write();
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (int.Parse(DataInRecordBuffer()) != _record.Manager.GetRcwRecordsCount())
                throw new Exception($"Number of employee records is not correct");

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
