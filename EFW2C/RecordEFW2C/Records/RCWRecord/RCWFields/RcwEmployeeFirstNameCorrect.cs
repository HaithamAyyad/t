using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    internal class RcwEmployeeFirstNameCorrect : FieldCorrect
    {
        public RcwEmployeeFirstNameCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 71;
            _length = 15;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwEmployeeFirstNameCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (_record.GetField(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) == null &&
                _record.GetField(typeof(RcwThirdPartySickPayndicatorCorrect).Name) == null &&
                _record.GetField(typeof(RcwRetirementPlanIndicatorCorrect).Name) == null &&
                !IsOneCorrectMoneyFieldProvided())
                throw new Exception($"{ClassDescription}: you must provoide at least one indecator or the SSN original field or at least one correct money field");


            return true;
        }

        public override bool IsRequired()
        {
            if (base.IsRequired())
                return true;

            if (_record.GetField(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) != null
                || _record.GetField(typeof(RcwThirdPartySickPayndicatorCorrect).Name) != null
                || _record.GetField(typeof(RcwRetirementPlanIndicatorCorrect).Name) != null)
                return true;

            if (IsOneCorrectMoneyFieldProvided())
                return true;

            return false;
        }

    }
}
