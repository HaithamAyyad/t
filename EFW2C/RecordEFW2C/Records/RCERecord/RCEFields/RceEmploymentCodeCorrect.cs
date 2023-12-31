﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-5-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceEmploymentCodeCorrect : FieldCorrect
    {
        public RceEmploymentCodeCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 222;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceEmploymentCodeCorrect(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var employmentCode = DataInRecordBuffer();

            if (!EnumHelper.IsEmploymentCodeValid(employmentCode))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.IsNotValidEmploymentCode));

            if (IsSameAsOriginalValue())
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustEnterBlanksIfNoCorrections));

            return true;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}
