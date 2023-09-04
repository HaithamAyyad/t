using EFW2C.Common.Enum;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCVRecord : RecordBase
    {
        public RCVRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCV.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            //no blank fields
            //question
            return new List<(int, int)>();
        }

        protected override List<FieldBase> CreateRequiredFields()
        {
            return new List<FieldBase>
            {
                new RcvRecordIdentifier(this)
            };
        }
    }
}
