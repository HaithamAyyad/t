﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class CountryCodeBase : FieldBase
    {
        public CountryCodeBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override void Write()
        {
            var rcaStateAbbreviation = _record.GetFields(typeof(RcaStateAbbreviation).Name);
            if (rcaStateAbbreviation != null)
            {
                if (!EnumHelper.IsStateTerritoriseMiltary(rcaStateAbbreviation.DataInRecordBuffer()))
                    base.Write();
            }
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (_record.IsForeign())
            {
                if (!EnumHelper.IsCountryCodeValid(DataInRecordBuffer()))
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
