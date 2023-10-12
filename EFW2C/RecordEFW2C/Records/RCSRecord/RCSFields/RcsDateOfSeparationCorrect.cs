﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcsDateOfSeparationCorrect : UnEmploymentReportingCorrect
    {
        public RcsDateOfSeparationCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 325;
            _length = 8;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsDateOfSeparationCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_record.Manager.IsUnEmployment && !string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                throw new Exception($"{ClassDescription} : This field only applies to unemployment reporting");

            return true;
        }
    }
}
