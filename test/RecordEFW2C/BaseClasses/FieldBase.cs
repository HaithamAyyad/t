
using EFW2C.Records;

namespace EFW2C.Fields
{
    public abstract class FieldBase
    {
        public string Name;
        protected RecordBase _record;
        protected int _pos;
        protected int _length;
        protected string _data;

        public FieldBase(RecordBase record, string data)
        {
            _record = record;
            _data = data;
            Name = "";
        }

        public abstract void Write();

        public abstract bool Verify();
    }
}
