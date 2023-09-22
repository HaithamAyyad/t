using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class RceEmploymentCodeOriginal : FieldOriginal
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

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if(!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                if(!IsCorrectionFieldProvided())
                    throw new Exception($"{ClassName}: the correction field is not provided");
            }

            return true;
        }
    }
}
