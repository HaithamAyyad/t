using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcsNumberOfWeeksWorkedCorrect : UnEmploymentReportingCorrect
    {
        public RcsNumberOfWeeksWorkedCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 299;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcsNumberOfWeeksWorkedCorrect(record, _data);
        }
    }
}
