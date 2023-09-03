﻿using System;
using System.Collections.Generic;
using System.Linq;
using EFW2C.Common.Constants;
using EFW2C.Fields;
using EFW2C.Manager;

namespace EFW2C.Records
{
    public abstract class RecordBase
    {
        private RecordManager _recordManager;
        public char[] RecordBuffer;

        protected List<FieldBase> _fields;
        protected List<FieldBase> _requiredFields;
        protected bool _isForeignAddres;

        public List<FieldBase> Fields { get { return _fields; } }
        public RecordManager RecordManager { get { return _recordManager; } }
        public string RecordName { get; set ; }
        public string ClassName { get; set ; }
        
        public RecordBase(RecordManager recordManager)
        {
            _recordManager = recordManager;
            RecordBuffer = new char[1024];
            _fields = new List<FieldBase>();
            ClassName = GetType().Name;

            RecordName = "";

            CreateRequiredFields();

            for (int i = 0; i < RecordBuffer.Length; i++)
            {
                RecordBuffer[i] = Constants.EmptyChar;
            }
        }

        public FieldBase GetField(string className)
        {
            return _fields.FirstOrDefault(field => field.ClassName == className);
        }
        public void AddField(FieldBase field)
        {
            if(string.IsNullOrEmpty(field.ClassName))
                throw new Exception($"{ClassName}:{field.ClassName} Field name missing to assign Name property");

            if (IsFieldExists(field))
                throw new Exception($"{field.ClassName} is already added");

            _fields.Add(field);
        }

        public bool IsFieldExists(FieldBase newField)
        {
            foreach(var field in _fields)
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
            if(string.IsNullOrEmpty(RecordName))
                throw new Exception($"{ClassName} RecordName can't be empty.");

            if (!CheckRequiredFields())
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

        private bool CheckRequiredFields()
        {
            foreach (var reqField in _requiredFields)
            {
                if(reqField.IsRequired() && !IsFieldExists(reqField))
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
                    if (RecordBuffer[i] != Constants.EmptyChar)
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
        protected abstract void CreateRequiredFields();

    }
}
