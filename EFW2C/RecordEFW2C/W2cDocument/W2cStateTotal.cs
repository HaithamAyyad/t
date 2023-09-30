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

        private string _recordIdentifier;
        public string RecordIdentifier
        {
            get { return _recordIdentifier; }
            set
            {
                if (_recordIdentifier != value)
                {
                    _recordIdentifier = value;
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
            mapDictionary.Add(nameof(RecordIdentifier), typeof(RcvRecordIdentifier).Name);
            mapDictionary.Add(nameof(SupplementalData), typeof(RcvSupplementalData).Name);

            return mapDictionary;
        }
    }
}
