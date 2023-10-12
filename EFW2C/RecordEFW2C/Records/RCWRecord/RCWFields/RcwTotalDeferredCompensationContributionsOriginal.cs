﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RcwTotalDeferredCompensationContributionsOriginal : MoneyOriginal
    {
        public RcwTotalDeferredCompensationContributionsOriginal(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 551;
            _length = 11;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwTotalDeferredCompensationContributionsOriginal(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if(!_record.Manager.IsTIB)
                throw new Exception($"{ClassDescription} : This field only should be provided when TIB is not set");

            return true;
        }
    }
}
