using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using EFW2C.Languages;

namespace EFW2C.Records
{
    internal abstract class RecordBase
    {
        private RecordManager _manager;
        protected List<FieldBase> _fields;
        private List<FieldBase> _helperFieldsList;
        private List<(int, int)> _blankFields;
        public RecordManager Manager { get { return _manager; } }
        public char[] RecordBuffer { get; private set; }
        public string RecordName { get; set; }
        public string ClassName { get; private set; }
        public string ClassDescription { get; private set; }
        public List<FieldBase> Fields { get { return _fields; } }
        public List<FieldBase> HelperFieldsList { get { return _helperFieldsList; } }

        public RecordBase(RecordManager recordManager, string recordName, char[] buffer = null)
        {
            _manager = recordManager;

            RecordName = recordName;

            RecordBuffer = buffer != null ? buffer : RecordBuffer = new string(' ', Constants.RecordLength).ToCharArray();

            _fields = new List<FieldBase>();

            ClassName = GetType().Name;
            ClassDescription = Language.Instance.LoadDescpitionString(ClassName);

            if (ClassDescription == "{Description-Not-Defined}")
            {
            }


            _blankFields = CreateBlankList();

            _helperFieldsList = CreateHelperFieldsList();

            AreFieldsBelongToRecord(this, _helperFieldsList);

            CheckHelperFieldsList();
        }

        protected void CloneData(RecordBase record)
        {
            record.Reset();

            record.RecordBuffer = (char[])RecordBuffer.Clone();

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
            var recordIdentifier = _helperFieldsList.FirstOrDefault(item => item.ClassName == $"{RecordName}RecordIdentifier");

            AddField(recordIdentifier.Clone(this));
        }

        public FieldBase CreateField(RecordBase record, string fieldName, string data)
        {
            var field = _helperFieldsList.FirstOrDefault(item => item.ClassName == fieldName);

            if (field == null)
                throw new Exception(Error.Instance.GetInternalError("CreateField()", Error.Instance.InvalidClass));

            return field.Clone(record, data);
        }

        public static bool AreFieldsBelongToRecord(RecordBase record, List<FieldBase> fields)
        {
            foreach (var field in fields)
            {
                if (record.ClassName.Substring(0, 3) != field.ClassName.Substring(0, 3))
                    throw new Exception(Error.Instance.GetInternalError(field.ClassName + " ", Error.Instance.DoesntBelongTo, record.ClassName));
            }

            return true;
        }

        protected static bool IsRecordNullOrEmpty(RecordBase record)
        {
            return record == null || record.IsRecordEmpty();
        }

        private bool CheckHelperFieldsList()
        {
            try
            {
                if (_helperFieldsList.Count == 0)
                    throw new Exception(Error.Instance.GetInternalError("HelperFieldList()" + " ", Error.Instance.IsEmpty));

                var duplicateNames = _helperFieldsList.GroupBy(item => item.ClassName)
                                                      .Where(group => group.Count() > 1)
                                                      .Select(group => group.Key)
                                                      .ToList();

                if (duplicateNames.Any())
                    throw new Exception(Error.Instance.GetInternalError(duplicateNames[0] + " ", Error.Instance.AlreadyAddedIn, "helperFieldList"));

                var pos = 0;

                while (pos != 1024)
                {
                    var fieldList = _helperFieldsList.Where(item => item.Pos == pos).ToList();

                    if (fieldList != null && fieldList.Count != 0)
                    {
                        if (fieldList.Count > 1)
                        {
                            var str = string.Join(", ", fieldList.Select(item => item.ClassName));
                                throw new Exception(Error.Instance.GetInternalError(ClassDescription, Error.Instance.SharedWithSamePosition, str));
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
                                throw new Exception(Error.Instance.GetInternalError(ClassDescription, pos.ToString() + " ", Error.Instance.PositionAddedMoreThanOnceInBlankList));

                            pos = pos + blankList[0].Item2;
                            continue;
                        }
                    }

                    break;
                }

                if (pos != 1024)
                    throw new Exception(Error.Instance.GetInternalError(ClassDescription, (pos + 1).ToString()+ " ", Error.Instance.HasNoFieldOrNotAddedToBlankList));
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
                throw new Exception(Error.Instance.GetInternalError("GetField()", Error.Instance.InvalidClass));

            return _fields.FirstOrDefault(field => field.ClassName == fieldClassName);
        }

        public void AddField(FieldBase field)
        {

            if (IsFieldExists(field))
                throw new Exception(Error.Instance.GetInternalError(field.ClassName, Error.Instance.AlreadyAddedTo, ClassDescription));

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

        public virtual bool Verify()
        {
            if (!CheckRequiredFields())
                return false;

            if (!CheckblankFields())
                return false;

            foreach (var field in _fields)
            {
                if (!field.Verify())
                    return false;
            }

            return true;
        }

        public bool IsRecordEmpty()
        {
            return string.IsNullOrWhiteSpace(new string(RecordBuffer, 0, 3));
        }

        public static RecordBase CreateRecord(RecordManager manager,string recordBuffer)
        {
            var record = null as RecordBase;

            var recordName = recordBuffer.Substring(0, 1) + recordBuffer.Substring(1, 2).ToLower();

            if (Enum.TryParse<RecordNameEnum>(recordName, out RecordNameEnum recordNameEnum) &&
                recordBuffer.Length == Constants.RecordLength)
            {
                switch (recordNameEnum)
                {
                    case RecordNameEnum.Rca:
                        record = new RcaRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rce:
                        record = new RceRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rcw:
                        record = new RcwRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rco:
                        record = new RcoRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rcs:
                        record = new RcsRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rct:
                        record = new RctRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rcu:
                        record = new RcuRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rcv:
                        record = new RcvRecord(manager, recordBuffer.ToCharArray());
                        break;
                    case RecordNameEnum.Rcf:
                        record = new RcfRecord(manager, recordBuffer.ToCharArray());
                        break;
                }
            }

            return record;
        }

        public static List<RecordBase> CreateRecordList(RecordManager manager, List<string> recordBufferList)
        {
            var recordList = new List<RecordBase>();

            foreach (var recordBuffer in recordBufferList)
            {
                var record = CreateRecord(manager, recordBuffer);

                if (record != null)
                {
                    record.CreateFieldsFromRecordBuffer();
                    recordList.Add(record);
                }
            }

            return recordList;
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
                        throw new Exception(Error.Instance.GetInternalError(ClassDescription, $"[{pos + 1} - {length}] ", Error.Instance.MustBeBlank));
                }
            }

            return true;
        }

        private bool CheckRequiredFields()
        {
            foreach (var reqField in _helperFieldsList)
            {
                if (reqField.IsRequired() && !IsFieldExists(reqField))
                    throw new Exception(Error.Instance.GetInternalError(reqField.ClassDescription, Error.Instance.FieldIsRequired));
            }

            return true;
        }

        protected abstract List<FieldBase> CreateHelperFieldsList();
        protected abstract List<(int, int)> CreateBlankList();
        public abstract RecordBase Clone(RecordManager manager);
    }
}
