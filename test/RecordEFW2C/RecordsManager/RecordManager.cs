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
            foreach (var record in _records)
            {
                if (!record.Verify())
                    return false;
            }

            return true;
        }
        public void AddRecord(RecordBase record)
        {
            _records.Add(record);
        }
    }

}
