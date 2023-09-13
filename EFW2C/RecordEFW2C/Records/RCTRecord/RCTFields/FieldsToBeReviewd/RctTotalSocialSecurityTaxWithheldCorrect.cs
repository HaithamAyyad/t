﻿using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RctTotalSocialSecurityTaxWithheldCorrect : SumFieldCorrect
    {
        public RctTotalSocialSecurityTaxWithheldCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 115;
            _length = 15;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var precedRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.Rce.ToString());

            if (precedRce == null)
                throw new Exception($"{ClassName} : RCE record is not provided");

            var employmentCodeField = precedRce.GetFields(typeof(RceEmploymentCodeCorrect).Name);

            var localData = DataInRecordBuffer();

            var employmentCode = employmentCodeField.DataInRecordBuffer();

            if (employmentCodeField != null)
            {
                if ((employmentCode == "Q" || employmentCode == "X") && !string.IsNullOrWhiteSpace(localData))
                    throw new Exception($"{ClassName} : must be blank");
            }

            return true;
        }
    }
}
