using System;

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

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            throw new Exception($"{ClassName} Field must be implement");

            //return true;
        }

        protected override bool IsNumeric()
        {
            throw new NotImplementedException();
        }

        protected override bool IsUpperCase()
        {
            throw new NotImplementedException();
        }
    }
}
