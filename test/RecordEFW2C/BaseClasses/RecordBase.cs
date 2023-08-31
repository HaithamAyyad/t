using System;
using System.Collections.Generic;
using EFW2C.Fields;

namespace EFW2C.Records
{
    public abstract class RecordBase
    {
        protected List<FieldBase> _fields = new List<FieldBase>();
        public char[] RecordBuffer;
        public string Name { get; set; } 
        // Define common properties or methods for your records here
        public RecordBase()
        {
            RecordBuffer = new char[1024];
            for (int i = 0; i < RecordBuffer.Length; i++)
            {
                RecordBuffer[i] = ' ';
            }

            Name = "name is missing";
        }

        public void AddField(FieldBase field)
        {
            if(string.IsNullOrEmpty(field.Name))
                throw new Exception($"Field name missing to assign Name property");

            if (!AddedOnce(field))
                throw new Exception($"{Name} is already added");

            _fields.Add(field);
        }

        private bool AddedOnce(FieldBase newField)
        {
            foreach(var field in _fields)
            {
                if (field.Name == newField.Name)
                    return false;
            }

            return true;
        }

        public abstract void Write();
        public abstract bool Verify();
        public bool IsRecordEmpty()
        {
            if (RecordBuffer == null)
                return true;

            for(var i = 0; i < RecordBuffer.Length; i++)
            {
                if (RecordBuffer[i] != ' ')
                    return false;
            }

            return true;
        }
    }
}
