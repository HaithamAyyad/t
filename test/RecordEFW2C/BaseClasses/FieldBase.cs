
using EFW2C.Common.Constants;
using EFW2C.Common.Enum;
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
        private FieldTypeEnum _fieldType;

        public string ClassName { get; set; }
        public FieldBase(RecordBase record, string data)
        {
            _pos = -1;
            _length = -1;

            _record = record;
            _fieldType = GetFieldType();

            _excludeFromWriting = false;

            _data = _fieldType == FieldTypeEnum.UpperCase_LeftJustify_Blank ? data.ToUpper() : data;

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

            if (_fieldType == FieldTypeEnum.Numerical_LeftJustify_Blank || _fieldType == FieldTypeEnum.Numerical_RightJustify_Zero)
            {
                foreach (char c in _data)
                {
                    if (!char.IsDigit(c))
                        throw new Exception($"{ClassName} all field char must be numerical");
                }
            }
            else
            {
                if (_fieldType == FieldTypeEnum.UpperCase_LeftJustify_Blank && !_data.IsUpper())
                    throw new Exception($"{ClassName} Field is not upper case");
            }

            return true;
        }
        public virtual void Write()
        {
            if (!VerifyWrite())
                return;
            switch (_fieldType)
            {
                case FieldTypeEnum.Numerical_RightJustify_Zero:

                    _record.RecordBuffer.Fill('0', _pos, _length);
                    Array.Copy(_data.ToCharArray(), 0, _record.RecordBuffer, _pos + _length - _data.Length, _data.Length);
                    break;

                case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                case FieldTypeEnum.Numerical_LeftJustify_Blank:
                case FieldTypeEnum.CaseSensitive_LeftJustify:
                    Array.Copy(_data.ToCharArray(), 0, _record.RecordBuffer, _pos, _data.Length);
                    break;
            }
        }

        public virtual bool Verify()
        {
            if (_length == -1)
                throw new Exception($"{ClassName} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassName} Postion is not set");

            if (!_excludeFromWriting)
            {
                switch(_fieldType)
                {
                    case FieldTypeEnum.Numerical_RightJustify_Zero:
                        for (var i = _pos; i < _pos + _length; i++)
                        {
                            if (!char.IsDigit(_record.RecordBuffer[i]))
                                throw new Exception($"{ClassName} all field char must be numerical");
                        }
                        break;
                    case FieldTypeEnum.Numerical_LeftJustify_Blank:
                        for (var i = _pos; i < _pos + _length; i++)
                        {
                            if (!(char.IsDigit(_record.RecordBuffer[i]) || _record.RecordBuffer[i] == Constants.EmptyChar ))
                                throw new Exception($"{ClassName} all field char must be numerical");
                        }

                        break;
                    case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                        for (var i = _pos; i < _pos + _length; i++)
                        {
                            if (_record.RecordBuffer[i] != Constants.EmptyChar && !char.IsUpper(_record.RecordBuffer[i]))
                                throw new Exception($"{ClassName} Field is not upper case");
                        }
                        break;
                    case FieldTypeEnum.CaseSensitive_LeftJustify:
                        break;
                }
            }

            return true;
        }
        protected abstract FieldTypeEnum GetFieldType();
    }
}

