using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class RcoMedicalSavingsAccountCodeROriginal : MoneyOriginal
    {
        public RcoMedicalSavingsAccountCodeROriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 56;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcoMedicalSavingsAccountCodeROriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}