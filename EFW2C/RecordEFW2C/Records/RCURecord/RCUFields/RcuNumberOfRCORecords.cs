using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-6-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcuNumberOfRCORecords : FieldBase
    {
        public RcuNumberOfRCORecords(RecordBase record)
            : base(record, "0")
        {
            _pos = 3;
            _length = 7;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcuNumberOfRCORecords(record);
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
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.NumberOfEmployeeOptionalRecordsIsNotCorrect));

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
