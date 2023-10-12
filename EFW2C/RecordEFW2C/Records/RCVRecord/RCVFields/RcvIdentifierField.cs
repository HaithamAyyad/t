using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Has 9-3-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RcvRecordIdentifier : RecordIdentifierBase
    {
        public RcvRecordIdentifier(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcvRecordIdentifier(record);
        }
    }
}
