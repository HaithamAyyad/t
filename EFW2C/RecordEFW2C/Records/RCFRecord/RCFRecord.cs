using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcfRecord : RecordBase
    {
        public RcfRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcf.ToString())
        {
            AddField(new RcfIdentifierField(this));
        }

        public RcfRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcf.ToString(), buffer)
        {
            AddField(new RcfIdentifierField(this));
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcfRecord = new RcfRecord(manager);

            CloneData(rcfRecord, manager);

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
                new RcfIdentifierField(this),
                new RcfNumberOfRCWRecord(this)
            };
        }
    }
}
