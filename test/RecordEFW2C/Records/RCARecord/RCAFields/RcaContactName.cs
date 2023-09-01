using System;

using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : hsa 9-1-2023
    //Reviewed by : 

    public class RcaContactName : FieldBase
    {
        public RcaContactName(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 211;
            _length = 27;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            return true;
        }

        protected override bool IsNumeric()
        {
            return false;
        }

        protected override bool IsUpperCase()
        {
            return true;
        }
    }
}
