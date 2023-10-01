using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RcfRecord : RecordBase
    {
        public RcfRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcf.ToString())
        {
            Prepare();
        }

        public RcfRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcf.ToString(), buffer)
        {
            Prepare();
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcfRecord = new RcfRecord(manager);

            CloneData(rcfRecord);

            return rcfRecord;
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (12, 1012)
            };
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcfRecordIdentifier(this),
                new RcfNumberOfRCWRecord(this)
            };
        }
    }
}
