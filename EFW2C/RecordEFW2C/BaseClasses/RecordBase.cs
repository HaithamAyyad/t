using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;

namespace EFW2C.Records
{
    internal abstract class RecordBase
    {
        private RecordManager _manager;
        protected List<FieldBase> _fields;
        private List<FieldBase> _helperFieldsList;
        private List<(int, int)> _blankFields;
        protected bool _isLocked;
        private bool _isVerified;
        public RecordManager Manager { get { return _manager; } }
        public char[] RecordBuffer { get; private set; }
        public string RecordName { get; set; }
        public string ClassName { get; set; }
        public List<FieldBase> Fields { get { return _fields; } }
        public bool IsLocked { get { return _isLocked; } }
        public bool IsVerified { get { return _isVerified; }}

        public RecordBase(RecordManager recordManager, string recordName, char[] buffer = null)
        {
            _manager = recordManager;

            RecordName = recordName;

            RecordBuffer = buffer != null ? buffer : RecordBuffer = new string(' ', Constants.RecordLength).ToCharArray();

            _fields = new List<FieldBase>();

            ClassName = GetType().Name;

            _blankFields = CreateBlankList();

            _helperFieldsList = CreateHelperFieldsList();

            AreFieldsBelongToRecord(this, _helperFieldsList);

            CheckHelperFieldsList();
        }

        public FieldBase CreateField(RecordBase record, string fieldName, string data)
        {
            var field = _helperFieldsList.FirstOrDefault(item => item.ClassName == fieldName);

            if(field == null)
                throw new Exception($"CreateField() : you are trying to get invalid class : {fieldName}");

            return field.Clone(record, data);
        }

        public static bool AreFieldsBelongToRecord(RecordBase record, List<FieldBase> fields)
        {
            foreach (var field in fields)
            {
                if (record.ClassName.Substring(0, 3) != field.ClassName.Substring(0, 3))
                    throw new Exception($"{field.ClassName} doesn't belong to {record.ClassName}");
            }

            return true;
        }

        public void Lock(bool isLocked = true)
        {
            if (isLocked)
            {
                if (!_isVerified && !Verify())
                    return;
            }

            _isLocked = isLocked;
        }

        private bool CheckHelperFieldsList()
        {
            try
            {
                if (_helperFieldsList.Count == 0)
                    throw new Exception($"{ClassName} : HelperFieldList() HelperFieldList is empty");

                var duplicateNames = _helperFieldsList.GroupBy(item => item.ClassName)
                                                      .Where(group => group.Count() > 1)
                                                      .Select(group => group.Key)
                                                      .ToList();

                if (duplicateNames.Any())
                    throw new Exception($"{duplicateNames[0]} : this field is already added in helperFieldList");

                var pos = 0;

                while (pos != 1024)
                {
                    var fieldList = _helperFieldsList.Where(item => item.Pos == pos).ToList();

                    if (fieldList != null && fieldList.Count != 0)
                    {
                        if (fieldList.Count > 1)
                        {
                            var str = string.Join(", ", fieldList.Select(item => item.ClassName));
                            throw new Exception($"{ClassName}: the following fileds are shared with same position : {str}");
                        }

                        pos = pos + fieldList[0].Length;
                        continue;
                    }

                    if (_blankFields != null)
                    {
                        var blankList = _blankFields.Where(item => item.Item1 == pos).ToList();

                        if (blankList != null && blankList.Count != 0)
                        {
                            if (blankList.Count > 1)
                                throw new Exception($"{ClassName}: the {pos} position is added more than once in blank list");

                            pos = pos + blankList[0].Item2;
                            continue;
                        }
                    }

                    break;
                }

                if (pos != 1024)
                    throw new Exception($"{ClassName} : {pos + 1} : has no field or not added to blank list");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public FieldBase GetField(string fieldClassName)
        {
            var validField = _helperFieldsList.FirstOrDefault(item => item.ClassName == fieldClassName);

            if (validField == null)
                throw new Exception($"GetField() : you are trying to get invalid class : {fieldClassName}");

            return _fields.FirstOrDefault(field => field.ClassName == fieldClassName);
        }
        public void AddField(FieldBase field)
        {

            if (IsFieldExists(field))
                throw new Exception($"{field.ClassName} is already added to {ClassName}");

            _isVerified = false;

            _fields.Add(field);
        }

        public bool IsFieldExists(FieldBase newField)
        {
            foreach (var field in _fields)
            {
                if (field.ClassName == newField.ClassName)
                    return true;
            }

            return false;
        }

        public void Write()
        {
            for (int i = 0; i < RecordBuffer.Length; i++)
                RecordBuffer[i] = Constants.WhiteSpaceChar;
            
            foreach (var field in _fields)
                field.Write();
        }

        public bool Verify()
        {
            _isVerified = false;

            if (string.IsNullOrWhiteSpace(new string(RecordBuffer, 0, 3)))
                throw new Exception($"{ClassName} RecordName can't be empty.");

            if (!CheckRequiredFields())
                return false;

            if (!CheckblankFields())
                return false;

            foreach (var field in _fields)
            {
                if (!field.Verify())
                {
                    return false;
                }
            }

            _isVerified = true;

            return _isVerified;
        }

        private bool CheckblankFields()
        {
            if (_blankFields != null)
            {
                foreach (var blankField in _blankFields)
                {
                    int pos = blankField.Item1;
                    int length = blankField.Item2;

                    var blankData = new string(RecordBuffer, pos, length);

                    if (!string.IsNullOrWhiteSpace(blankData))
                        throw new Exception($"{ClassName} : data from {pos} with length {length} must be blank");
                }
            }

            return true;
        }

        private bool CheckRequiredFields()
        {
            foreach (var reqField in _helperFieldsList)
            {
                if (reqField.IsRequired() && !IsFieldExists(reqField))
                {
                    throw new Exception($"{reqField.ClassName} : Field is required");
                }
            }

            return true;
        }

        public bool IsRecordEmpty()
        {
            if (RecordBuffer != null)
            {
                for (var i = 0; i < RecordBuffer.Length; i++)
                {
                    if (!char.IsWhiteSpace(RecordBuffer[i]))
                        return false;
                }
            }

            return true;
        }

        public void CreateFieldsFromRecordBuffer()
        {
            _fields.Clear();

            foreach(var field in _helperFieldsList)
            {
                var data = new string(RecordBuffer, field.Pos, field.Length);

                if (!string.IsNullOrWhiteSpace(data))
                {
                    var newField = field.Clone(this, data.TrimEnd());

                    AddField(newField);
                }
            }
        }

        protected void CloneData(RecordBase record)
        {
            if(record.IsLocked)
                throw new Exception($"{ClassName} record is locked");

            record._isLocked = _isLocked;

            record.RecordBuffer = (char[])RecordBuffer.Clone();

            record.Reset();

            foreach (var field in _fields)
                record.AddField(field.Clone(record));
        }

        public void Reset()
        {
            _fields.Clear();

            RecordBuffer = new string(' ', Constants.RecordLength).ToCharArray();
        }
        public void Prepare()
        {
            var identifierField = _helperFieldsList.FirstOrDefault(item => item.ClassName == $"{RecordName}IdentifierField");

            AddField(identifierField.Clone(this));
        }

        protected abstract List<FieldBase> CreateHelperFieldsList();
        protected abstract List<(int, int)> CreateBlankList();
        public abstract RecordBase Clone(RecordManager manager);
    }
}
