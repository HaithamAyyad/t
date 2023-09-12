using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-5-2023
    //Reviewed by : 

    public class SumFieldOriginal : FieldOriginal
    {
        public SumFieldOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override void Write()
        {
            var sum = _record.Manager.GetRecordsFeildsSum(ClassName, _record, _record.SumRecordClassName);

            if (sum > 0)
            {
                _data = sum.ToString();
                base.Write();
            }
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();
            var sum = _record.Manager.GetRecordsFeildsSum(ClassName, _record, _record.SumRecordClassName);
            Int32.TryParse(localData, out int value);

            if (sum != value)
                throw new Exception($"Total of {ClassName} is not correct");

            return true;
        }
    }
}
