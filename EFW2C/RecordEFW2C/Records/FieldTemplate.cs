using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class FieldTemplate : FieldBase
    {
        public FieldTemplate(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new FieldTemplate(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            throw new Exception($"{ClassName} Field must be implemented");

            //return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            throw new NotImplementedException();
            //return FieldTypeEnum.;
        }

        public override bool IsRequired()
        {
            throw new NotImplementedException();
        }
    }
}
