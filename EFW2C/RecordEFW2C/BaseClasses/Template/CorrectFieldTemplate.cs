using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class CorrectFieldTemplate : FieldBase
    {
        public CorrectFieldTemplate(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if(!IsOriginalNullOrWhiteSpace())
            {
                switch(DataInRecordBuffer())
                {
                    case "":
                        break;
                }

                throw new Exception($"{ClassName} Field must be 0 or 1");
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            throw new NotImplementedException();
            //return FieldTypeEnum.;
        }

        public override bool IsRequired()
        {
            return !IsOriginalNullOrWhiteSpace();
        }
    }
}
