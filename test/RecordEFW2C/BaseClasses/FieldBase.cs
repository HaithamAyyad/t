
using EFW2C.Common.Constants;
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
        protected bool _excludeFromWriting;
        private bool _upperCase;
        private bool _numeric;

        public string ClassName { get; set; }
        public FieldBase(RecordBase record, string data)
        {
            _pos = -1;
            _length = -1;

            _record = record;
            _numeric = IsNumeric();
            _upperCase = IsUpperCase();

            _excludeFromWriting = false;

            _data = _upperCase ? data.ToUpper() : data;

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

            if (_length < _data.Length)
               throw new Exception($"{ClassName} Length exceeds the allowed length");

            if (_numeric)
            {
                foreach (char c in _data)
                {
                    if (!char.IsDigit(c))
                        throw new Exception($"{ClassName} all field char must be numerical");
                }
            }
            else
            {
                if (_upperCase && !_data.IsUpper())
                    throw new Exception($"{ClassName} Field is not upper case");
            }

            return true;
        }
        public virtual void Write()
        {
            if (!VerifyWrite())
                return;

            if (_numeric)
            {
                _record.RecordBuffer.Fill('0', _pos, _length);

                Array.Copy(_data.ToCharArray(), 0, _record.RecordBuffer, _pos + _length - _data.Length, _data.Length);
            }
            else
            {
                Array.Copy(_data.ToCharArray(), 0, _record.RecordBuffer, _pos, _data.Length);
            }
        }

        public virtual bool Verify()
        {
            if (_length == -1)
                throw new Exception($"{ClassName} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassName} Postion is not set");

            if (_numeric && !_excludeFromWriting)
            {
                for(var i = _pos; i < _pos + _length; i++)
                {
                    if (!char.IsDigit(_record.RecordBuffer[i]))
                        throw new Exception($"{ClassName} all field char must be numerical");
                }
            }
            else
            {
                if (_upperCase)
                {
                    for (var i = _pos; i < _pos + _length; i++)
                    {
                        if (_record.RecordBuffer[i] != Constants.EmptyChar && !char.IsUpper(_record.RecordBuffer[i]))
                            throw new Exception($"{ClassName} Field is not upper case");
                    }
                }
            }

            return true;
        }
        protected abstract bool IsUpperCase();
        protected abstract bool IsNumeric();
    }
}

