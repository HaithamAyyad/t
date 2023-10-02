using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public abstract class DocumentPart : INotifyPropertyChanged
    {
        protected W2cDocument _document;
        internal RecordBase _record;
        private Dictionary<string, string> _mapPropFieldDictionary;

        protected Dictionary<string, string> DataDictionary { get; }
        internal RecordBase Record { get { return _record; } }
        public DocumentPart(W2cDocument document)
        {
            _document = document;
            DataDictionary = new Dictionary<string, string>();
            _mapPropFieldDictionary = CreateMapPropFieldDictionay();
        }

        public void Prepare()
        {
            _record.Reset();
            _record.Prepare();

            foreach (var data in DataDictionary)
            {
                if (!string.IsNullOrWhiteSpace(data.Value))
                    _record.AddField(_record.CreateField(_record,_mapPropFieldDictionary[data.Key], data.Value));
            }

            _record.Write();
        }

        protected void AddData(string value, [CallerMemberName] string propertyName = null)
        {
            //throw new Exception($"{ClassName} data can't be null or empty");

            DataDictionary[propertyName] = value;
        }

        public virtual bool Verify()
        {
            if (!_record.Verify())
                return false;

            return true;
        }

        protected abstract Dictionary<string, string> CreateMapPropFieldDictionay();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
