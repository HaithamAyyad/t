using System;
using System.Collections.Generic;
using EFW2C.Fields;

namespace EFW2C.Records
{
    public abstract class RecordBase
    {
        public char[] RecordBuffer;
        protected List<FieldBase> _fields;
        protected List<FieldBase> _requiredFields;

        public string Name { get; set ; }
        
        public RecordBase()
        {
            RecordBuffer = new char[1024];
            _fields = new List<FieldBase>();
            _requiredFields = new List<FieldBase>();

            CreateRequiredFields();

            for (int i = 0; i < RecordBuffer.Length; i++)
            {
                RecordBuffer[i] = ' ';
            }

            Name = "name is missing, you need to fill this from child class";
        }

        protected abstract void CreateRequiredFields();

        public void AddField(FieldBase field)
        {
            if(string.IsNullOrEmpty(field.ClassName))
                throw new Exception($"Field name missing to assign Name property");

            if (IsFieldExists(field))
                throw new Exception($"{Name} is already added");

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

        public abstract void Write();
        public virtual bool Verify()
        {
            foreach (var reqField in _requiredFields)
            {
                if(!IsFieldExists(reqField))
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
                    if (RecordBuffer[i] != ' ')
                        return false;
                }
            }

            return true;
        }

        public abstract void AbstractMethod();
    }
}
