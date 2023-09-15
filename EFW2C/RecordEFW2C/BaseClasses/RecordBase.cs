using System;
using System.Collections.Generic;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;

namespace EFW2C.Records
{
    public abstract class RecordBase
    {
        private RecordManager _manager;
        public char[] RecordBuffer;

        protected List<FieldBase> _fields;
        private List<FieldBase> _verifyFieldsList;
        private List<(int, int)> _blankFields;
        protected bool _isForeignAddres;

        public List<FieldBase> Fields { get { return _fields; } }
        public RecordManager Manager { get { return _manager; } }
        public string RecordName { get; set; }
        public string ClassName { get; set; }
        public string SumRecordClassName { get; set; }

        public RecordBase(RecordManager recordManager)
        {
            _manager = recordManager;
            RecordBuffer = new string(' ', Constants.RecordLength).ToCharArray();
            _fields = new List<FieldBase>();
            ClassName = GetType().Name;

            RecordName = "";

            _blankFields = CreateBlankList();

            _verifyFieldsList = CreateVerifyFieldsList();

            IsFeildsBelongToClass(_verifyFieldsList);

            CheckVerifyFieldList();

            CheckFieldsBelongToRecord(_verifyFieldsList);
        }

        public bool IsFeildsBelongToClass(List<FieldBase> fields)
        {
            foreach (var field in fields)
            {
                if (ClassName.Substring(0, 3) != field.ClassName.Substring(0, 3))
                    throw new Exception($"{field.ClassName} doesn't belong to {ClassName}");
            }

            return true;
        }

        private bool CheckVerifyFieldList()
        {
            try
            {
                if (_verifyFieldsList.Count == 0)
                    throw new Exception($"{ClassName} : CheckVerifyFieldList() verify list is empty");

                var duplicateNames = _verifyFieldsList.GroupBy(item => item.ClassName)
                                                      .Where(group => group.Count() > 1)
                                                      .Select(group => group.Key)
                                                      .ToList();

                if (duplicateNames.Any())
                    throw new Exception($"{duplicateNames[0]} : this field is already added in verfiy field list");

                var pos = 0;

                while (pos != 1024)
                {
                    var fieldList = _verifyFieldsList.Where(item => item.Pos == pos).ToList();

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
            catch(Exception ex)
            {
                throw ex;
            }

            return true;
        }

        private void CheckFieldsBelongToRecord(List<FieldBase> fields)
        {
            foreach (var field in fields)
            {
                if (ClassName.Substring(0, 3) != field.ClassName.Substring(0, 3))
                    throw new Exception($"{field.ClassName} doesn't belong to {ClassName} in veryfy fields list");
            }
        }

        public FieldBase GetField(string fieldClassName)
        {
            var validField = _verifyFieldsList.FirstOrDefault(field => field.ClassName == fieldClassName);

            if (validField == null)
                throw new Exception($" GetFields : you are trying to get invalid class : {fieldClassName}");

            return _fields.FirstOrDefault(field => field.ClassName == fieldClassName);
        }
        public void AddField(FieldBase field)
        {
            if (string.IsNullOrWhiteSpace(field.ClassName))
                throw new Exception($"{ClassName}:{field.ClassName} Field name missing to assign Name property");

            if (IsFieldExists(field))
                throw new Exception($"{field.ClassName} is already added to {ClassName}");

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
            foreach (var field in _fields)
                field.Write();
        }

        public bool Verify()
        {
            if (string.IsNullOrWhiteSpace(RecordName))
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
            return true;
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
            foreach (var reqField in _verifyFieldsList)
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

        public void SetForeignAddress(bool value)
        {
            _isForeignAddres = value;
        }

        public bool IsForeign()
        {
            return _isForeignAddres;
        }
        protected abstract List<FieldBase> CreateVerifyFieldsList();
        protected abstract List<(int, int)> CreateBlankList();

    }
}
