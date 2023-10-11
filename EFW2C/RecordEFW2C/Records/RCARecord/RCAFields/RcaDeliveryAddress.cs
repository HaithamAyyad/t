
using EFW2C.Records;
using System.Linq;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaDeliveryAddress : DeliveryAddressBase
    {
        public RcaDeliveryAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 110;
            _length = 22;
        }


        public override FieldBase Clone(RecordBase record)
        {
            return new RcaDeliveryAddress(record, _data);
        }

        public override void Write()
        {
            base.Write();

            var rcaLocationAddressName = typeof(RcaLocationAddress).Name;

            if (IsFieldNullOrWhiteSpace(_record.GetField(rcaLocationAddressName)))
            {
                var rcaLocationAddressField = _record.HelperFieldsList.FirstOrDefault(item => item.ClassName == rcaLocationAddressName);

                rcaLocationAddressField = rcaLocationAddressField.Clone(_record, DataInRecordBuffer());
                rcaLocationAddressField.Write();
            }
        }
        public override bool IsRequired()
        {
            return true;
        }
    }
}