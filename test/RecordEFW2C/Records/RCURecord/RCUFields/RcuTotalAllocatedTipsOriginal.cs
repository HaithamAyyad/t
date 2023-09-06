﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-6-2023
    //Reviewed by : 

    public class RcuTotalAllocatedTipsOriginal : FieldOriginal
    {
        public RcuTotalAllocatedTipsOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 10;
            _length = 15;
        }

        public override void Write()
        {
            var sum = _record.Manager.GetRcoRecordsFeildsSum(ClassName, _record);

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

            return true;
        }
    }
}