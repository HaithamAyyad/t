using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-3-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaResubIndicator : FieldBase
    {
        public RcaResubIndicator(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 316;
            _length = 1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaResubIndicator(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if(!EnumHelper.IsResubIndicatorCodeValid(localData, true))
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeEitherZeroOrOne));

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            // we set this true , while testing AccuW2c, it is not mentioned in spec.
            return true;
        }
    }
}
