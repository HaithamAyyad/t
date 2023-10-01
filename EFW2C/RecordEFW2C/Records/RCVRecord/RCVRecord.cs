using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RcvRecord : RecordBase
    {
        private RceRecord _parent;
        public RceRecord Parent { get { return _parent; } }

        public RcvRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcv.ToString())
        {
            Prepare();
        }

        public RcvRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcv.ToString(), buffer)
        {
            Prepare();
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcvRecord = new RcvRecord(manager);

            CloneData(rcvRecord);

            return rcvRecord;
        }

        public void SetParent(RceRecord parent)
        {
            _parent = parent;
            SetDirty();
        }

        public override bool Verify()
        {
            if (_parent == null)
                throw new Exception($"State-Total : must be added to Employer");

            return base.Verify();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return null;
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcvRecordIdentifier (this),
                new RcvSupplementalData(this, "Helper"),
            };
        }
    }
}
