using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    public class RcwEmployeeLastNameCorrect : FieldCorrect
    {
        public RcwEmployeeLastNameCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 101;
            _length = 20;
            IgnoreOriginalField = true;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (_record.GetFields(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) == null &&
                _record.GetFields(typeof(RcwThirdPartySickPayndicatorCorrect).Name) == null &&
                _record.GetFields(typeof(RcwRetirementPlanIndicatorCorrect).Name) == null &&
                 IsOriginalNullOrWhiteSpace() &&
                !IsOneCorrectMoneyFieldProvided())
                throw new Exception($"{ClassName}: you must provoide at least one indecator or the SSN original field or at least one correct money filed");


            return true;
        }

        public override bool IsRequired()
        {
            if (base.IsRequired())
                return true;

            if (_record.GetFields(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) != null
                || _record.GetFields(typeof(RcwThirdPartySickPayndicatorCorrect).Name) != null
                || _record.GetFields(typeof(RcwRetirementPlanIndicatorCorrect).Name) != null)
                return true;

            if (IsOneCorrectMoneyFieldProvided())
                return true;

            return false;
        }
    }
}
