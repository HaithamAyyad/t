﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    internal class RceThirdPartySickPayCorrect : FieldCorrect
    {
        public RceThirdPartySickPayCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 224;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceThirdPartySickPayCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            switch (DataInRecordBuffer())
            {
                case "0":
                case "1":
                    break;
                default:
                    throw new Exception($"{ClassDescription} Field must be 0 or 1");
            }

            if (IsSameAsOriginalValue())
                throw new Exception($"{ClassDescription} and Orignal Must enter blanks in both fields if no corrections are being reported to this data"); ;

            return true;
        }
    }
}
