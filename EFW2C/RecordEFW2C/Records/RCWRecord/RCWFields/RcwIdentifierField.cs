using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by  : Hsa 9-4-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RcwRecordIdentifier : RecordIdentifierBase
    {
        public RcwRecordIdentifier(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwRecordIdentifier(record);
        }
    }
}
