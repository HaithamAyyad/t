using System;
using System.Collections.Generic;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-4-2023
    //Reviewed by : HSA on ........

    public class RceEinAgent : EinFieldBase
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

        public override void Write()
        {
            var rceAgentIndicator = _record.GetField(typeof(RceAgentIndicator).Name);
            if (rceAgentIndicator != null)
            {
                if (rceAgentIndicator.DataInRecordBuffer() == ((int)AgentIndicatorCodeEnum.One).ToString())
                    base.Write();
            }
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
                        throw new Exception($"{ClassName} must not be empty, since the {rceAgentIndicator} set to 1" );
                }
            }

            return true;
        }

        public override bool IsRequired()
        {
            var rceAgentIndicator = _record.GetField(typeof(RceAgentIndicator).Name);
            if (rceAgentIndicator != null)
            {
                if (rceAgentIndicator.DataInRecordBuffer() == ((int)AgentIndicatorCodeEnum.One).ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
