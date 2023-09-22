using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class UnEmploymentReportingCorrectTemplate : UnEmploymentReportingCorrect
    {
        public UnEmploymentReportingCorrectTemplate(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new UnEmploymentReportingCorrectTemplate(record, _data);
        }
    }
}
