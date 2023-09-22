﻿using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcvRecord : RecordBase
    {
        public RcvRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rcv.ToString();
        }
        public RcvRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, buffer)
        {
            RecordName = RecordNameEnum.Rcv.ToString();
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcvRecord = new RcvRecord(manager);

            CloneData(rcvRecord, manager);

            return rcvRecord;
        }
        protected override List<(int, int)> CreateBlankList()
        {
            return null;
        }

        protected override List<FieldBase> CreateVerifyFieldsList()
        {
            return new List<FieldBase>
            {
                new RcvIdentifierField (this),
                new RcvSupplementalData(this, "dummy"),
            };
        }
    }
}
