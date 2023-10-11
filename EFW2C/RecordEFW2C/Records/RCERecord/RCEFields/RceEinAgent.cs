using System;
using System.Collections.Generic;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-4-2023
    //Reviewed by : Hsa 10-11-2023

    internal class RceEinAgent : EinFieldBase
    {
        public RceEinAgent(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 26;
            _length = 9;
        }

        public override FieldBase Clone(RecordBase record)
        {
            return new RceEinAgent(record, _data);
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var rceAgentIndicator = _record.GetField(typeof(RceAgentIndicator).Name);
            if (rceAgentIndicator != null)
            {
                if (rceAgentIndicator.DataInRecordBuffer() == ((int)AgentIndicatorCodeEnum.One).ToString())
                {
                    if(string.IsNullOrEmpty(DataInRecordBuffer()))
                        throw new Exception($"{ClassDescription} if {rceAgentIndicator.ClassDescription} equals one, then this field can't be blank");
                }
            }

            if (rceAgentIndicator == null || (rceAgentIndicator.DataInRecordBuffer() != ((int)AgentIndicatorCodeEnum.One).ToString()))
            {
                if (!string.IsNullOrEmpty(DataInRecordBuffer()))
                    throw new Exception($"{ClassDescription} Must be blank, unless '{{'Employer AgentIndicator'}}' set to 1");
            }

            return true;
        }

        public override bool IsRequired()
        {
            var rceAgentIndicator = _record.GetField(typeof(RceAgentIndicator).Name);
            if (rceAgentIndicator != null)
            {
                if (rceAgentIndicator.Data == ((int)AgentIndicatorCodeEnum.One).ToString())
                {
                    if(string.IsNullOrWhiteSpace(DataInRecordBuffer()))
                        throw new Exception($"{ClassDescription} if {rceAgentIndicator.ClassDescription} equals one, then this field can't be blank");
                }
            }

            return false;
        }
    }
}
