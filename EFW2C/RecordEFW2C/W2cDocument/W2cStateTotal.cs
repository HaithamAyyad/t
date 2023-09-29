using EFW2C.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cStateTotal : DocumentPart
    {
        public W2cStateTotal(W2cDocument document)
            :base(document)
        {

        }

        private string _identifierField;
        public string IdentifierField
        {
            get { return _identifierField; }
            set
            {
                if (_identifierField != value)
                {
                    _identifierField = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _supplementalData;
        public string SupplementalData
        {
            get { return _supplementalData; }
            set
            {
                if (_supplementalData != value)
                {
                    _supplementalData = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        public override bool Verify()
        {
            throw new NotImplementedException();
        }
        protected override Dictionary<string, string> CreateMapPropFieldDictionay()
        {
            var mapDictionary = new Dictionary<string, string>();
            mapDictionary.Add(nameof(IdentifierField), typeof(RcvIdentifierField).Name);
            mapDictionary.Add(nameof(SupplementalData), typeof(RcvSupplementalData).Name);

            return mapDictionary;
        }
    }
}
