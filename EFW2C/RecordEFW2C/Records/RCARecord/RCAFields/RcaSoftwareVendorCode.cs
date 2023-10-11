using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
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
                    if (string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception($"{ClassDescription} When Software Code is Off-the-Shelf Software '99' this field should be provided");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception($"{ClassDescription} When Software Code is In-House Program '98' this field must be empty");
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
