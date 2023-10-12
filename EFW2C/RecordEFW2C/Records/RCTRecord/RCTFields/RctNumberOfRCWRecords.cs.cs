using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-8-2023
    //Reviewed by : Hsa 10-12-2023

    internal class RctNumberOfRCWRecords : FieldBase
    {
        public RctNumberOfRCWRecords(RecordBase record)
            : base(record, "0")
        {
            _pos = 3;
            _length = 7;
        }
        public override FieldBase Clone(RecordBase record)
        {
            return new RctNumberOfRCWRecords(record);
        }

        public override void Write()
        {
            _data = ((RctRecord)_record).Parent.GetRcwRecordsCount().ToString();
            base.Write();
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (int.Parse(DataInRecordBuffer()) != ((RctRecord)_record).Parent.GetRcwRecordsCount())
                throw new Exception($"{ClassDescription} number of Employee records is not correct");

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_RightJustify_Zero;
        }

        public override bool IsRequired()
        {
            return false;
        }
    }
}
