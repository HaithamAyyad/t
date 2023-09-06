
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaDeliveryAddress : DeliveryAddressBase
    {
        public RcaDeliveryAddress(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 110;
            _length = 22;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}