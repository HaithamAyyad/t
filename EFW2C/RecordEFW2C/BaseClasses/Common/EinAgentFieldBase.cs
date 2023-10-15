using System;
using System.Collections.Generic;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 10-10-2023
    //Reviewed by : HSA 10-10-203

    internal abstract class EinAgentFieldBase : FieldBase
    {
        public EinAgentFieldBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
            _fieldFormat = FieldFormat.Hyphen;
        }

        public abstract override FieldBase Clone(RecordBase record);
        public override bool Verify()
        {
            if (!base.Verify())
                return false;
                
            var invalidList = new List<string>
            {
                "00","07", "08", "09", "17", "18", "19", "28", "29",
                "49", "69", "70", "78", "79", "89"
            };

            var str = string.Concat(_record.RecordBuffer[_pos], _record.RecordBuffer[_pos + 1]);

            foreach (var invalidStr in invalidList)
            {
                if (invalidStr == str)
                {
                    throw new Exception($"{ClassDescription} Must not start with {string.Join(", ", invalidList)}");
                }
            }

            return true;
        }

        protected override FieldTypeEnum GetFieldType()
        {
            return FieldTypeEnum.Numerical_Only;
        }

        public override bool IsRequired()
        {
            return true;
        }
    }
}