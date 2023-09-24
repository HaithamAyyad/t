using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    internal class UnEmploymentReportingOriginalTemplate : UnEmploymentReportingOriginal
    {
        public UnEmploymentReportingOriginalTemplate(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new UnEmploymentReportingOriginalTemplate(record, _data);
        }
    }
}
