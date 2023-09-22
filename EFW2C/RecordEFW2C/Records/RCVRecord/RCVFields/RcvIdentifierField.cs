using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Has 9-3-2023
    //Reviewed by : 

    public class RcvIdentifierField : IdentifierFieldBase
    {
        public RcvIdentifierField(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcvIdentifierField(record);
        }
    }
}
