﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcsStateQuarterlyUnemploymentInsuranceTotalWagesOriginal : MoneyOriginal
    {
        public RcsStateQuarterlyUnemploymentInsuranceTotalWagesOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 275;
            _length = 11;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_record.Manager.IsUnEmployment() && !string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                throw new Exception($"{ClassName} : This field only applies to unemployment reporting ");

            return true;
        }
    }
}