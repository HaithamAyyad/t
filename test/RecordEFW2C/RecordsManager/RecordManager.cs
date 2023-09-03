using System;
using System.Collections.Generic;

using EFW2C.Records;

namespace EFW2C.Manager
{
    public class RecordManager
    {
        List<RecordBase> _records;
        public RecordManager()
        {
            _records = new List<RecordBase>();
        }

        public void write()
        {
            foreach (var record in _records)
                record.Write();
        }

        public bool Verify()
        {
            //if (!IsFeildsBelogToClass())
            //    return true;

            foreach (var record in _records)
            {
                if (!record.Verify())
                    return false;
            }

            return true;
        }

        private bool IsFeildsBelogToClass()
        {
            foreach (var record in _records)
            {
                foreach (var field in record.Fields)
                {
                    if (record.ClassName.Substring(0,3) != field.ClassName.Substring(0,3).ToUpper())
                        throw new Exception($"{field.ClassName} doesn't belog to {record.ClassName}");
                }
            }

            return true;
        }

        public void AddRecord(RecordBase record)
        {
            _records.Add(record);
        }
    }

}
