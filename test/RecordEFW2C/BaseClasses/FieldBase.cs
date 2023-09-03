﻿
using EFW2C.Common.Constants;
using EFW2C.Common.Enum;
using EFW2C.Extensions;
using EFW2C.Records;
using System;
using System.Text.RegularExpressions;
using System.Windows;

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

        public string Data { get { return _data;} }

        protected bool VerifyEmail(string email)
        {
            return true;
        }

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

            switch (_fieldType)
            {
                case FieldTypeEnum.Numerical_Only:
                case FieldTypeEnum.Numerical_LeftJustify_Blank:
                case FieldTypeEnum.Numerical_RightJustify_Zero:

                    if (_fieldType == FieldTypeEnum.Numerical_Only)
                    {
                        if (_data.Length != _length)
                            throw new Exception($"{ClassName} lenght is not correct\n it must be {_length}");
                    }

                    foreach (char c in _data)
                    {
                        if (!char.IsDigit(c))
                            throw new Exception($"{ClassName} field must be numerical");
                    }
                    break;

                case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                    if (!_data.IsUpper())
                        throw new Exception($"{ClassName} Field is not upper case");
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

            MessageBox.Show($"verifcation for{ClassName} Successed");
            return true;
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
                    case FieldTypeEnum.Numerical_Only:
                    case FieldTypeEnum.Numerical_RightJustify_Zero:
                        for (var i = _pos; i < _pos + _length; i++)
                        {
                            if (!char.IsDigit(_record.RecordBuffer[i]))
                                throw new Exception($"{ClassName} field must be numerical");
                        }
                        break;
                    case FieldTypeEnum.Numerical_LeftJustify_Blank:
                        for (var i = _pos; i < _pos + _length; i++)
                        {
                            if (!(char.IsDigit(_record.RecordBuffer[i]) || _record.RecordBuffer[i] == Constants.EmptyChar ))
                                throw new Exception($"{ClassName} field must be numerical");
                        }
                        break;
                    case FieldTypeEnum.UpperCase_LeftJustify_Blank:
                        for (var i = _pos; i < _pos + _length; i++)
                        {
                            var str = new string(_record.RecordBuffer, _pos, _length);
                            if (!str.IsUpper())
                                throw new Exception($"{ClassName} Field nust be upper case");
                        }
                        break;
                    case FieldTypeEnum.CaseSensitive_LeftJustify:
                        break;
                    default:
                        throw new Exception($"{_fieldType} is not handeled");
                }
            }

            return true;
        }

        public bool IsCountryCodeValid(string str)
        {
            foreach (var countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                if (countryCode.ToString() == str)
                    return true;
            }

            return false;
        }

        public bool IsMiltaryPostOffice(string state)
        {
            foreach (var zipCode in Enum.GetValues(typeof(MILITARY_POST_OFFICES)))
            {
                if (zipCode.ToString() == state)
                    return true;
            }

            return false;

        }

        public bool IsTerritorise(string state)
        {
            foreach (var zipCode in Enum.GetValues(typeof(TERRITORIES_AND_POSSESSIONS)))
            {
                if (zipCode.ToString() == state)
                    return true;
            }

            return false;
        }

        public static bool IsUsaState(string state)
        {
            foreach (var zipCode in Enum.GetValues(typeof(ZipCodeEnum)))
            {
                if (zipCode.ToString() == state)
                    return true;
            }

            return false;
        }

        public bool IsStateTerritoriseMiltary()
        {
            var str = new string(_record.RecordBuffer, _pos, _length);
            return IsUsaState(str) || IsTerritorise(str) || IsMiltaryPostOffice(str);
        }


        public static bool IsValidStateCode(string state, bool value = false)
        {
            foreach (var zipCode in Enum.GetValues(typeof(ZipCodeEnum)))
            {
                if (value)
                {
                    if (((int)zipCode).ToString("D2") == state)
                        return true;
                }
                else
                {
                    if (zipCode.ToString() == state)
                        return true;
                }
            }

            return false;
        }

        public abstract bool IsRequired();
        protected abstract FieldTypeEnum GetFieldType();
    }
}

