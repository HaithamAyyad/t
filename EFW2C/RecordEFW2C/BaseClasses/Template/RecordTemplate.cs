using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RecordTemplate : RecordBase
    {
        public RecordTemplate(RecordManager recordManager)
            : base(recordManager, "")
        {
        }

        public override RecordBase Clone(RecordManager manager)
        {
            return null;
        }
        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>()
            {
                //(24, 5),               
            };
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            var requiredFields = new List<FieldBase>();

            return requiredFields;
        }
    }
}
