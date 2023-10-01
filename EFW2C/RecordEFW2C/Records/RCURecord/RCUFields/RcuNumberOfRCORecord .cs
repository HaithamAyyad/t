using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-6-2023
    //Reviewed by : 

    internal class RcuNumberOfRCORecord : FieldBase
    {
        public RcuNumberOfRCORecord(RecordBase record)
            : base(record, "0")
        {
            _pos = 3;
            _length = 7;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcuNumberOfRCORecord(record);
        }


        public override void Write()
        {
            _data = ((RcuRecord)_record).Parent.GetRcoRecordsCount().ToString();
            base.Write();

        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (int.Parse(DataInRecordBuffer()) != ((RcuRecord)_record).Parent.GetRcoRecordsCount())
                throw new Exception($"{ClassName} number of RCO is not correct");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_RightJustify_Zero;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
