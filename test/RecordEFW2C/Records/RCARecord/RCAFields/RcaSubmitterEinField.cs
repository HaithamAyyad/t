using System;
using System.Collections.Generic;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    public class RcaSubmitterEinField : FieldBase
    {
        public RcaSubmitterEinField(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 3;
            _length = 9;
            Name = GetType().Name;
        }

        public override void Write()
        {
            var data = (_data as string).ToCharArray();

            if (data.Length != _length)
                return;

            Array.Copy(data, 0, _record.RecordBuffer, _pos, _length);
        }

        public override bool Verify()
        {
            if ((_data as string).Length != _length)
                throw new Exception($"{Name} Length is not correct");

            var invalidList = new List<string>
            {
                "07", "08", "09", "17", "18", "19", "28", "29",
                "49", "69", "70", "78", "79", "89"
            };

            for (int i = _pos; i < _pos + _length; i++)
            {
                if (!char.IsDigit(_record.RecordBuffer[i]))
                    throw new Exception($"{Name} all field char must be numerical");
            }

            var str = string.Concat(_record.RecordBuffer[_pos], _record.RecordBuffer[_pos + 1]);

            foreach (var invalidStr in invalidList)
            {
                if (invalidStr == str)
                {
                    throw new Exception($"{Name} can't be started with the following: {string.Join(", ", invalidList)}");
                }
            }

            return true;
        }
    }
}