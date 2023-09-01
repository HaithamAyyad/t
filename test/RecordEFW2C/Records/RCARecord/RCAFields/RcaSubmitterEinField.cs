using System;
using System.Collections.Generic;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-1-2023
    //Reviewed by : HSA on ........

    public class RcaSubmitterEinField : FieldBase
    {
        public RcaSubmitterEinField(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 9;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;
                
            var invalidList = new List<string>
            {
                "07", "08", "09", "17", "18", "19", "28", "29",
                "49", "69", "70", "78", "79", "89"
            };

            var str = string.Concat(_record.RecordBuffer[_pos], _record.RecordBuffer[_pos + 1]);

            foreach (var invalidStr in invalidList)
            {
                if (invalidStr == str)
                {
                    throw new Exception($"{ClassName} can't be started with the following: {string.Join(", ", invalidList)}");
                }
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_LeftJustify_Blank;
        }
    }
}