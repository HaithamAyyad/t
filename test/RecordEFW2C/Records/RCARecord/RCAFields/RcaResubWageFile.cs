using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hSa 9-3-2023
    //Reviewed by : 

    public class RcaResubWageFile : FieldBase
    {
        public RcaResubWageFile(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 317;
            _length = 6;
        }

        public override void Write()
        {
            var rcaResubIndicator = _record.GetFields(typeof(RcaResubIndicator).Name);

            if (rcaResubIndicator != null && rcaResubIndicator.DataInRecordBuffer() == "1")
                base.Write();
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var rcaResubIndicator = _record.GetFields(typeof(RcaResubIndicator).Name);
            var localData = DataInRecordBuffer();

            if (rcaResubIndicator != null)
            {
                switch (rcaResubIndicator.DataInRecordBuffer())
                {
                    case "1":
                        if (string.IsNullOrWhiteSpace(localData))
                            throw new Exception($"{ClassName} cannot be empty because {rcaResubIndicator.ClassName} is set to 1");
                        break;

                    case "0":
                        if (!string.IsNullOrWhiteSpace(Data))
                            throw new Exception($"{ClassName} must be empty because {rcaResubIndicator.ClassName} is set to 0");
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
            return true;
        }
    }
}
