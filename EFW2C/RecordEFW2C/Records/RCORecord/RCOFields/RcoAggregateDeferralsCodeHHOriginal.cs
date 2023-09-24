using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    internal class RcoAggregateDeferralsCodeHHOriginal : MoneyOriginal
    {
        public RcoAggregateDeferralsCodeHHOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 254;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcoAggregateDeferralsCodeHHOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}