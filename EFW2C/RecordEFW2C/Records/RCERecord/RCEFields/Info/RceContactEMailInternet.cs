using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-4-2023
    //Reviewed by : 

    internal class RceContactEMailInternet : ContactEMailInternetBase
    {
        public RceContactEMailInternet(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 284;
            _length = 40;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceContactEMailInternet(record, _data);
        }
    }
}
