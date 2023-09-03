using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaLocationAddress : FieldBase
    {
        public RcaLocationAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 88;
            _length = 22;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
        public override void Write()
        {
            var data = _data;

            if (string.IsNullOrWhiteSpace(_data))
            {
                var rcaDeliveryAddress = _record.GetField(typeof(RcaDeliveryAddress).Name);
                if (rcaDeliveryAddress != null)
                    _data = rcaDeliveryAddress.Data;
            }

            base.Write();

            _data = data;

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
