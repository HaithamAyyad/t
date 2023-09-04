using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by  : HSA on 9-4-2023
    //Reviewed by : HSA on ........

    public class RcuIdentifierField : IdentifierFieldBase
    {
        public RcuIdentifierField(RecordBase record)
            : base(record, record.RecordName)
        {
            _pos = 0;
            _length = 3;
        }
    }
}
