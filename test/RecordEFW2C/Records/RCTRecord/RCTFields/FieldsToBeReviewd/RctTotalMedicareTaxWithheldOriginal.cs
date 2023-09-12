﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RctTotalMedicareTaxWithheldOriginal : SumFieldOriginal
    {
        public RctTotalMedicareTaxWithheldOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 160;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var precedeRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.Rce.ToString());

            if (precedeRce == null)
                throw new Exception($"{ClassName} : RCE record is not provided");

            var employmentCode = precedeRce.GetFields(typeof(RceEmploymentCodeCorrect).Name);

            var taxYear = _record.Manager.TaxYear;

            var localData = DataInRecordBuffer();

            if (employmentCode != null)
            {
                if (employmentCode.DataInRecordBuffer() == "X" && taxYear >= 1983)
                {
                    if (!string.IsNullOrWhiteSpace(localData))
                        throw new Exception($"{ClassName} : must be blank becuase tax year is 1983 and employment code is X");
                }
            }

            return true;
        }
    }
}
