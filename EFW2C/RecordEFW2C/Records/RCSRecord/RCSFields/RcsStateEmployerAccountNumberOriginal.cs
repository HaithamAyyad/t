using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    internal class RcsStateEmployerAccountNumberOriginal : UnEmploymentReportingOriginal
    {
        public RcsStateEmployerAccountNumberOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 343;
            _length = 20;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsStateEmployerAccountNumberOriginal(record, _data);
        }
    }
}
