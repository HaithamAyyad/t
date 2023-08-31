
using EFW2C.Records;
using System;

namespace EFW2C.Fields
{
    public abstract class FieldBase
    {
        protected RecordBase _record;
        protected int _pos = -1;
        protected int _length =-1;
        protected string _data;

        public string ClassName { get; set; }
        public FieldBase(RecordBase record, string data)
        {
            _record = record;
            _data = data;
            ClassName = "";
        }

        internal bool VerifyWrite()
        {
            if (_length == -1)
                throw new Exception($"{ClassName} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassName} Postion is not set");

            if (_pos < 0 || _pos + _length > _record.RecordBuffer.Length)
                throw new Exception($"{ClassName} Postion and Length is not correct");

            return true;
        }

        public abstract void Write();

        public virtual bool Verify()
        {
            if (_length == -1)
                throw new Exception($"{ClassName} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassName} Postion is not set");

            return true;

        }
    }
}
