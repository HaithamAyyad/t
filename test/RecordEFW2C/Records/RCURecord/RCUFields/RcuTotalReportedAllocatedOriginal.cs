using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-6-2023
    //Reviewed by : 

    public class RcuTotalReportedAllocatedOriginal : FieldOriginal
    {
        public RcuTotalReportedAllocatedOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 10;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}