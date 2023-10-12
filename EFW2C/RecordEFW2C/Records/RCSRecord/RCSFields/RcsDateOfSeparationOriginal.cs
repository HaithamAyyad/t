using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsDateOfSeparationOriginal : UnEmploymentReportingOriginal
    {
        public RcsDateOfSeparationOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 317;
            _length = 8;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsDateOfSeparationOriginal(record, _data);
        }
    }
}
