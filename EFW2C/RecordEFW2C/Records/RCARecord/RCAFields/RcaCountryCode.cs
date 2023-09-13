﻿using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaCountryCode : FieldBase
    {
        public RcaCountryCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 209;
            _length = 2;
        }

        public override void Write()
        {
            var rcaStateAbbreviation = _record.GetField(typeof(RcaStateAbbreviation).Name);
            if (rcaStateAbbreviation != null)
            {
                if (!rcaStateAbbreviation.IsStateTerritoriseMiltary())
                    base.Write();
            }
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (_record.IsForeign())
            {
                if (!IsCountryCodeValid(DataInRecordBuffer()))
                    throw new Exception($"{ClassName} country code is not correct");

            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return _record.IsForeign();
        }
    }
}