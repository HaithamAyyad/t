using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaSoftwareCode : FieldBase
    {
        public RcaSoftwareCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 29;
            _length = 2;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new RcaSoftwareCode(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if (!EnumHelper.IsSoftwareCodeValid(localData, true))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeEither98Or99));

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            //Note 4000, This field is not required in the spec. but didn't pass on AccuW2C 2011
            return true;
        }
    }
}
