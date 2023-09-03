using EFW2C.Common.Enum;
using EFW2C.Fields;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCVRecord : RecordBase
    {
        public RCVRecord()
        {
            RecordName = RecordNameEnum.RCV.ToString();
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields = new List<FieldBase>();

            _requiredFields.Add(new RcvRecordIdentifier(this));
        }
    }
}
