﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-9-2023
    //Reviewed by : Hsa 10-12-2-23

    internal class RcwRetirementPlanIndicatorCorrect : FieldCorrect
    {
        public RcwRetirementPlanIndicatorCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 1005;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcwRetirementPlanIndicatorCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();
            if (!(localData == "1" || localData == "0"))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeEitherZeroOrOne));

            return true;
        }
    }
}
