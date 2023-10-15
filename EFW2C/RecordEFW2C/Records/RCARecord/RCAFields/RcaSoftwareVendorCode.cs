using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : Hsa 10-10-2023

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
                    if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.CantBeBlankIf, "Software Code 99"));
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, "Software Code 99"));
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
            return false;
        }
    }
}
