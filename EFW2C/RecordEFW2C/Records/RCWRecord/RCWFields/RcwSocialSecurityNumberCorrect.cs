﻿using EFW2C.Common.Enums;
using EFW2C.Records;
using System;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    public class RcwSocialSecurityNumberCorrect : FieldCorrect
    {
        public RcwSocialSecurityNumberCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 12;
            _length = 9;

            IgnoreOriginalField = true;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (_record.GetField(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) == null &&
                _record.GetField(typeof(RcwThirdPartySickPayndicatorCorrect).Name) == null  &&
                _record.GetField(typeof(RcwRetirementPlanIndicatorCorrect).Name) == null    &&
                 IsOriginalNullOrWhiteSpace() &&
                !IsOneCorrectMoneyFieldProvided())
               throw new Exception($"{ClassName}: you must provoide at least one indecator or the SSN original field or at least one correct money filed");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            if (base.IsRequired())
                return true;

            if (_record.GetField(typeof(RcwStatutoryEmployeeIndicatorCorrect).Name) != null
                || _record.GetField(typeof(RcwThirdPartySickPayndicatorCorrect).Name) != null
                || _record.GetField(typeof(RcwRetirementPlanIndicatorCorrect).Name) !=null)
                return true;

            if (IsOneCorrectMoneyFieldProvided())
                return true;

            return false;
        }
    }
}
