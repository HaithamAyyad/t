﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class UnEmploymentReportingOriginal : FieldOriginal
    {
        public UnEmploymentReportingOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
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