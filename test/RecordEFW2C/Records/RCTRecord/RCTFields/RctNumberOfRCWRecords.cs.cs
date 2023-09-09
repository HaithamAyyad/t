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
    //Created by : HSA 9-8-2023
    //Reviewed by : 

    public class RctNumberOfRCWRecords : FieldBase
    {
        public RctNumberOfRCWRecords(RecordBase record)
            : base(record, "0")
        {
            _pos = 3;
            _length = 7;
        }

        public override void Write()
        {
            var precedRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.Rce.ToString());

            if (precedRce != null)
            {
                _data = _record.Manager.GetRecordsBetween(_record, precedRce, _record.SumRecordClassName)?.Count.ToString();
                base.Write();
            }

        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var count = -1;

            var precedRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.Rce.ToString());

            if (precedRce != null)
            {
                var list = _record.Manager.GetRecordsBetween(_record, precedRce, _record.SumRecordClassName);
                if (list != null)
                    count = list.Count;
            }

            Int32.TryParse(DataInRecordBuffer(), out int value);
            if (value != count)
                throw new Exception($"{ClassName} number of RCW is not correct");

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
