using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsNumberOfWeeksWorkedOriginal : UnEmploymentReportingOriginal
    {
        public RcsNumberOfWeeksWorkedOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 297;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsNumberOfWeeksWorkedOriginal(record, _data);
        }
    }
}
