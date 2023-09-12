using System;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class RcaForeignStateProvince : FieldBase
    {
        public RcaForeignStateProvince(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 171;
            _length = 23;
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
