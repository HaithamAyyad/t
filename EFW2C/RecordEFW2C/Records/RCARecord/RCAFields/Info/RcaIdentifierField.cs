using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by  : HSA on 9-1-2023
    //Reviewed by : HSA on ........

    public class RcaIdentifierField : IdentifierFieldBase
    {
        public RcaIdentifierField(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }
    }
}
