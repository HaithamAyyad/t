﻿using EFW2C.Common.Enums;
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
            AddField(new RcvIdentifierField(this));
        }

        public RcvRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcv.ToString(), buffer)
        {
            AddField(new RcvIdentifierField(this));
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
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return null;
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcvIdentifierField (this),
                new RcvSupplementalData(this, "Helper"),
            };
        }
    }
}
