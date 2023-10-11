using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by  : Hsa on 9-1-2023
    //Reviewed by : Hsa on 10-10-2023

    internal class RcaRecordIdentifier : RecordIdentifierBase
    {
        public RcaRecordIdentifier(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaRecordIdentifier(record);
        }
    }
}
