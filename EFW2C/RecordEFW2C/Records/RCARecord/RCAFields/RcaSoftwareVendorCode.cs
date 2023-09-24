using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : 

    internal class RcaSoftwareVendorCode : FieldBase
    {
        public RcaSoftwareVendorCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 20;
            _length = 4;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaSoftwareVendorCode(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var rcaSoftwareCode = _record.GetField(typeof(RcaSoftwareCode).Name) as RcaSoftwareCode;
            if (rcaSoftwareCode != null)
            {
                var softwareCode = rcaSoftwareCode.DataInRecordBuffer();

                if (softwareCode == ((int)SoftwareCodeEnum.Code_99).ToString())
                {
                    if (string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception($"{ClassName} Field must not be empty, since software code marked as Off-the-ShelfSoftware");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception($"{ClassName} Field must be empty, since software code not marked as Off-the-ShelfSoftware");

                }
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            var rcaSoftwareCode = _record.GetField(typeof(RcaSoftwareCode).Name);
            return rcaSoftwareCode != null;
        }
    }
}
