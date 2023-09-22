using System;
using System.Collections.Generic;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-1-2023
    //Reviewed by : HSA on ........

    public class RcaEinSubmitterField : EinFieldBase
    {
        public RcaEinSubmitterField(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaEinSubmitterField(record, _data);
        }
    }
}
