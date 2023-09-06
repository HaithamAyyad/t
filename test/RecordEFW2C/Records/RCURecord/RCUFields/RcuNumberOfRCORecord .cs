using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-6-2023
    //Reviewed by : 

    public class RcuNumberOfRCORecord : FieldBase
    {
        public RcuNumberOfRCORecord(RecordBase record)
            : base(record, "0")
        {
            _pos = 3;
            _length = 7;

            var precedRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.RCE.ToString());

            if (precedRce != null)
            {
                _data = _record.Manager.GetRecordsBetween(_record, precedRce, RecordNameEnum.RCO.ToString())?.Count.ToString();
            }
        }
        
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var count = "-1";

            var precedRce = _record.Manager.GetPrecedRecord(_record, RecordNameEnum.RCE.ToString());

            if (precedRce != null)
            {
                count = _record.Manager.GetRecordsBetween(_record, precedRce, RecordNameEnum.RCO.ToString())?.Count.ToString();

            }

            if (DataInRecordBuffer() != count)
                throw new Exception($"{ClassName} number of RCO is not correct");

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
