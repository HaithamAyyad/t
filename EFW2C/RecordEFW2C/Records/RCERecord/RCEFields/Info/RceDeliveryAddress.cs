
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RceDeliveryAddress : DeliveryAddressBase
    {
        public RceDeliveryAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 122;
            _length = 22;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceDeliveryAddress(record, _data);
        }
    }
}