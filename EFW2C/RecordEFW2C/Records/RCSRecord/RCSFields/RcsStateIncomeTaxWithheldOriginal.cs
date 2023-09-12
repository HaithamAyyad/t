using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcsStateIncomeTaxWithheldOriginal : MoneyOriginal
    {
        public RcsStateIncomeTaxWithheldOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 419;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}