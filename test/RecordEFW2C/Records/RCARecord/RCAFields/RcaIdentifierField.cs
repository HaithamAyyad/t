﻿using System;

using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by  : HSA on 9-1-2023
    //Reviewed by : HSA on ........
    public class RcaIdentifierField : FieldBase
    {
        public RcaIdentifierField(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 0;
            _length = 3;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_record.RecordBuffer.Compare(_pos, _record.RecordName.ToCharArray(), _length))
                throw new Exception($"{ClassName} Field must be {_record.RecordName}");

            return true;
        }

        protected override bool IsNumeric()
        {
            return false;
        }

        protected override bool IsUpperCase()
        {
            return true;
        }
    }
}
