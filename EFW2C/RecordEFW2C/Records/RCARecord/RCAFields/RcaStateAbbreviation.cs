using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : Hsa 10-10-2023

    internal class RcaStateAbbreviation : StateAbbreviationBase
    {
        public RcaStateAbbreviation(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 154;
            _length = 2;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RcaStateAbbreviation(record, _data);
        }

        public override bool IsRequired()
        {
            if (!IsFieldNullOrWhiteSpace(_record.GetField(typeof(RcaForeignStateProvince).Name)))
                return false;

            return true;
        }

    }
}