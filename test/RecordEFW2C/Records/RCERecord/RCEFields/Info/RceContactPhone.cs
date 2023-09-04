using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2013
    //Reviewed by : 

    public class RceContactPhone : ContactPhoneBase
    {
        public RceContactPhone(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 254;
            _length = 15;
        }
    }
}
