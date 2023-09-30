using System;
using System.Collections.Generic;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-1-2023
    //Reviewed by : HSA on ........

    internal class RcaEinSubmitter : EinFieldBase
    {
        public RcaEinSubmitter(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaEinSubmitter(record, _data);
        }
    }
}
