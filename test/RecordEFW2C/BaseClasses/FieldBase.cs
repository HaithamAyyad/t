
using EFW2C.Extensions;
using EFW2C.Records;
using System;

namespace EFW2C.Fields
{
    public abstract class FieldBase
    {
        protected RecordBase _record;
        protected int _pos;
        protected int _length;
        protected string _data;
        private bool _upperCase;
        private bool _numeric;

        public string ClassName { get; set; }
        public FieldBase(RecordBase record, string data)
        {
            _pos = -1;
            _length = -1;

            _record = record;
            _data = data;
            
            _numeric = IsNumeric();
            _upperCase = IsUpperCase();

            ClassName = GetType().Name;
        }

        private bool VerifyWrite()
        {
            if (string.IsNullOrEmpty(_data))
                throw new Exception($"{ClassName} data can't be null or empty");

            if (_length == -1)
                throw new Exception($"{ClassName} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassName} Postion is not set");

            if (_pos < 0 || _pos + _length > _record.RecordBuffer.Length)
                throw new Exception($"{ClassName} Postion and Length is not correct");

            if (_length != _data.Length)
                throw new Exception($"{ClassName} Length is not correct");

            if (_upperCase && !_numeric && !_data.IsUpper())
                throw new Exception($"{ClassName} Field is not upper case");

            if (_numeric)
            {
                foreach (char c in _data)
                {
                    if (!char.IsDigit(c))
                        throw new Exception($"{ClassName} all field char must be numerical");
                }
            }

            return true;
        }
        public virtual void Write()
        {
            if (!VerifyWrite())
                return;

            Array.Copy(_data.ToCharArray(), 0, _record.RecordBuffer, _pos, _length);
        }

        public virtual bool Verify()
        {
            if (_length == -1)
                throw new Exception($"{ClassName} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassName} Postion is not set");

            return true;

        }
        protected abstract bool IsUpperCase();
        protected abstract bool IsNumeric();
}
}

