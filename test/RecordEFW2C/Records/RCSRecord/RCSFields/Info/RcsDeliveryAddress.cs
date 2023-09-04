
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    public class RcsDeliveryAddress : DeliveryAddressBase
    {
        public RcsDeliveryAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 155;
            _length = 22;
        }
    }
}