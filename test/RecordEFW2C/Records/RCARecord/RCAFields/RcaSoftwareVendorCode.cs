using System;
using EFW2C.Common.Constants;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-1-2023
    //Reviewed by : 

    public class RcaSoftwareVendorCode : FieldBase
    {
        public RcaSoftwareVendorCode(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 20;
            _length = 4;
        }

        public override void Write()
        {
            var rcaSoftwareCode = _record.GetField("RcaSoftwareCode") as RcaSoftwareCode;

            if (rcaSoftwareCode != null && rcaSoftwareCode.OffShelfSoftware())
            {
                base.Write();
            }
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var rcaSoftwareCode = _record.GetField("RcaSoftwareCode") as RcaSoftwareCode;

            if (rcaSoftwareCode != null && !rcaSoftwareCode.OffShelfSoftware())
            {
                for (int i = _pos; i < _pos + _length; i++)
                {
                    if (_record.RecordBuffer[i] != Constants.EmptyChar)
                        throw new Exception($"{ClassName} Field must be empty since software code is In-House Program");
                }
            }

            return true;
        }

        protected override bool IsNumeric()
        {
            return true;
        }

        protected override bool IsUpperCase()
        {
            return false;
        }
    }
}
