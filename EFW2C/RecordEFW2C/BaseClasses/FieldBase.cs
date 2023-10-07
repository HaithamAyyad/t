﻿using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;
using EFW2C.Resource.Language;
using System;
using System.Windows.Forms;

namespace EFW2C.Fields
{
    internal abstract class FieldBase
    {
        protected RecordBase _record;
        protected int _pos;
        protected int _length;
        protected string _data;
        private FieldTypeEnum _fieldType;
        protected FieldFormat _fieldFormat;

        public string ClassName { get; private set; }
        public string ClassDescription { get; private set; }
        public string Data { get { return _data; } }
        public int Length { get { return _length; } }
        public int Pos { get { return _pos; } }
        public FieldFormat FieldFormat { get { return _fieldFormat; } }

        public FieldBase(RecordBase record, string data)
        {
            _pos = -1;
            _length = -1;

            _record = record;
            _fieldType = GetFieldType();
            _fieldFormat = FieldFormat.Data;

            switch (_fieldType)
            {
                case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                    data = data.ToUpper();
                    break;
                case FieldTypeEnum.UpperCase_Address_LeftJustify_Blank:
                    data = data.ToUpper();
                    break;
            }

            _data = data;

            ClassName = GetType().Name;
            ClassDescription = Language.Instance.LoadDescpitionString(ClassName);

            if (ClassDescription == "{Description-Not-Defined}")
            {
            }
        }

        public static bool IsFieldNullOrWhiteSpace(FieldBase field)
        {
            return field == null || string.IsNullOrWhiteSpace(field.DataInRecordBuffer());
        }

        public FieldBase Clone(RecordBase record, string data)
        {
            var field = Clone(record);

            switch (_fieldType)
            {
                case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                    data = data.ToUpper();
                    break;
                case FieldTypeEnum.UpperCase_Address_LeftJustify_Blank:
                    data = data.ToUpper();
                    break;
            }


            field._data = data;

            return field;
        }

        public string DataInRecordBuffer()
        {
            return new string(_record.RecordBuffer, _pos, _length);
        }

        protected bool VerifyEmail(string email)
        {
            return true;
        }

        private bool VerifyWrite()
        {
            if (string.IsNullOrWhiteSpace(_data))
                throw new Exception($"{ClassDescription} data can't be null or empty");

            if (_length == -1)
                throw new Exception($"{ClassDescription} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassDescription} Postion is not set");

            if (_pos < 0 || _pos + _length > _record.RecordBuffer.Length)
                throw new Exception($"{ClassDescription} Postion and Length is not correct");

            if (_length < _data.Length)
                throw new Exception($"{ClassDescription} Length exceeds {_length} ");

            switch (_fieldType)
            {
                case FieldTypeEnum.Numerical_Only:
                case FieldTypeEnum.Numerical_LeftJustify_Blank:
                case FieldTypeEnum.Numerical_RightJustify_Zero:

                    if (_fieldType == FieldTypeEnum.Numerical_Only)
                    {
                        if (_data.Length != _length)
                            throw new Exception($"{ClassDescription} lenght is not correct\n it must be {_length}");
                    }

                    foreach (char c in _data)
                    {
                        if (!char.IsDigit(c))
                            throw new Exception($"{ClassDescription} field must be numerical");
                    }
                    break;

                case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                    if (!_data.IsUpper())
                        throw new Exception($"{ClassDescription} Field must be upper case");
                    break;
                case FieldTypeEnum.UpperCase_Address_LeftJustify_Blank:
                    var tempData = _data.Replace(",", string.Empty);
                    if (!tempData.IsUpper())
                        throw new Exception($"{ClassDescription} Field must be upper case");
                    break;
                case FieldTypeEnum.CaseSensitive_LeftJustify:
                    break;
                default:
                    throw new Exception($"{_fieldType} is not handeled");
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

                case FieldTypeEnum.Numerical_Only:
                case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                case FieldTypeEnum.Numerical_LeftJustify_Blank:
                case FieldTypeEnum.CaseSensitive_LeftJustify:
                    Array.Copy(_data.ToCharArray(), 0, _record.RecordBuffer, _pos, _data.Length);
                    break;
            }
        }
        public bool VerifcationTestOnly()
        {
            Write();
            if (!Verify())
                return false;

            MessageBox.Show($"verifcation for{ClassDescription} Successed");
            return true;
        }

        public virtual bool Verify()
        {
            if (_length == -1)
                throw new Exception($"{ClassDescription} Length is not set");

            if (_pos == -1)
                throw new Exception($"{ClassDescription} Postion is not set");

            switch (_fieldType)
            {
                case FieldTypeEnum.Numerical_Only:
                case FieldTypeEnum.Numerical_RightJustify_Zero:
                    for (var i = _pos; i < _pos + _length; i++)
                    {
                        if (!char.IsDigit(_record.RecordBuffer[i]))
                            throw new Exception($"{ClassDescription} field must be numerical");
                    }
                    break;
                case FieldTypeEnum.Numerical_LeftJustify_Blank:
                    for (var i = _pos; i < _pos + _length; i++)
                    {
                        if (!(char.IsDigit(_record.RecordBuffer[i]) || char.IsWhiteSpace(_record.RecordBuffer[i])))
                            throw new Exception($"{ClassDescription} field must be numerical");
                    }
                    break;
                case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                    var str = DataInRecordBuffer();
                    if (!str.IsUpper())
                        throw new Exception($"{ClassDescription} Field must be upper case");
                    break;
                case FieldTypeEnum.UpperCase_Address_LeftJustify_Blank:
                    str = DataInRecordBuffer().Replace(",","");
                    if (!str.IsUpper())
                        throw new Exception($"{ClassDescription} Field must be upper case");
                    break;
                case FieldTypeEnum.CaseSensitive_LeftJustify:
                    break;
                default:
                    throw new Exception($"{_fieldType} is not handeled");
            }

            return true;
        }

        public abstract bool IsRequired();
        protected abstract FieldTypeEnum GetFieldType();
        public abstract FieldBase Clone(RecordBase record);
    }
}

