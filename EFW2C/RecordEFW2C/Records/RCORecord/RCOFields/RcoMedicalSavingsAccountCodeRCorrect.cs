using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    internal class RcoMedicalSavingsAccountCodeRCorrect : MoneyCorrect
    {
        public RcoMedicalSavingsAccountCodeRCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 67;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcoMedicalSavingsAccountCodeRCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }
    }
}
