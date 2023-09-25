using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public abstract class DocumentPart
    {
        protected W2cDocument _document;
        internal RecordBase _record;
        protected bool _isLocked;
        private Dictionary<string, string> _mapPropFieldDictionary;
        protected Dictionary<string, string> DataDictionary { get; }
        public DocumentPart(W2cDocument document)
        {
            _document = document;
            _mapPropFieldDictionary = CreateMapPropFieldDictionay();
            DataDictionary = new Dictionary<string, string>();
        }
        public bool Lock(bool value)
        {
            if (value)
            {
                Prepare();

                if (!Verify())
                    return false;
            }
            else
            {
                if (_document != null)
                {
                    _document.Remove(this);
                    _document = null;
                }
            }

            _isLocked = value;

            return true;
        }

        private void Prepare()
        {
            _record.ResetFields();

            foreach (var data in DataDictionary)
            {
                if (!string.IsNullOrWhiteSpace(data.Value))
                    _record.AddField(_record.CreateField(_record,_mapPropFieldDictionary[data.Key], data.Value));
            }

            _record.Write();
        }

        public bool IsLocked()
        {
            return _isLocked;
        }

        protected void AddData(string value, [CallerMemberName] string propertyName = null)
        {
            if (_isLocked)
            {

            }
            //throw new Exception($"{ClassName} data can't be null or empty");

            DataDictionary[propertyName] = value;
        }

        public abstract bool Verify();
        protected abstract Dictionary<string, string> CreateMapPropFieldDictionay();
    }
}
