using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Has 9-5-2023
    //Reviewed by : Has 10-11-2023 

    internal class RceEmploymentCodeOriginal : FieldOriginal
    {
        public RceEmploymentCodeOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 221;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceEmploymentCodeOriginal(record, _data);
        }
    }
}
