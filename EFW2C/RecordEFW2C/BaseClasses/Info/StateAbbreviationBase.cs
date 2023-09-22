using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public abstract class StateAbbreviationBase : FieldBase
    {
        public StateAbbreviationBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override void Write()
        {
            if (!_record.ForeignAddress)
                base.Write();
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_record.ForeignAddress)
            {
                if (!EnumHelper.IsValidStateCode(DataInRecordBuffer()))
                    throw new Exception($"{ClassName} State code is not valid");
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
