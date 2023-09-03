using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-2-2023
    //Reviewed by : 

    public class RcaStateAbbreviation : FieldBase
    {
        public RcaStateAbbreviation(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 154;
            _length = 2;
        }

        public override void Write()
        {
            if (!_record.IsForeign())
                base.Write();
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_record.IsForeign())
            {
                var state = new string(_record.RecordBuffer, _pos, _length);

                if (!IsValidStateCode(state))
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
            return true;
        }
    }
}
