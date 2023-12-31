﻿using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-1-203

    internal abstract class CountryCodeBase : FieldBase
    {
        public CountryCodeBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override void Write()
        {
            base.Write();
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if (!string.IsNullOrWhiteSpace(localData))
            {
                var stateAbbreviationClassName = $"{_record.ClassName.Substring(0, 3)}StateAbbreviation";
                var stateAbbreviationField = _record.GetField(stateAbbreviationClassName);

                if (!IsFieldNullOrWhiteSpace(stateAbbreviationField))
                {
                    if (EnumHelper.IsStateTerritoriseMiltary(stateAbbreviationField.DataInRecordBuffer()))
                        throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, "StateAbbreviation Blank"));
                }

                if (!EnumHelper.IsCountryCodeValid(localData))
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.CountryCodeIsNotCorrect));
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.UpperCase_LeftJustify_Blank;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
