
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    internal class RcwDeliveryAddress : DeliveryAddressBase
    {
        public RcwDeliveryAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 143;
            _length = 22;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwDeliveryAddress(record, _data);
        }
    }
}