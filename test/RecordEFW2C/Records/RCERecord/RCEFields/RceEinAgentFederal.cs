using System;
using System.Collections.Generic;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-4-2023
    //Reviewed by : HSA on ........

    public class RceEinAgentFederal : EinFieldBase
    {
        public RceEinAgentFederal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 16;
            _length = 9;
        }
    }
}
