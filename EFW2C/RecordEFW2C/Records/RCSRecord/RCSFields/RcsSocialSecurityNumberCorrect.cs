using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    public class RcsSocialSecurityNumberCorrect : FieldCorrect
    {
        public RcsSocialSecurityNumberCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos =  24;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsSocialSecurityNumberCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var lacalData = DataInRecordBuffer();

            if (lacalData.Substring(0, 3) == "666" || lacalData.Substring(0, 1) == "9")
                throw new Exception($"{ClassName}: Social Security Number, should not start with '666' or '9'");

            return true;
        }
    }
}
