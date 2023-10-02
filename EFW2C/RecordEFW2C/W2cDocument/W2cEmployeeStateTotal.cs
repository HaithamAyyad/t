using EFW2C.Fields;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cEmployeeStateTotal : DocumentPart
    {
        private W2cEmployer _parent;

        public W2cEmployer Parent { get { return _parent; } }
        internal RcvRecord InternalRecord { get { return ((RcvRecord)_record); } }

        public W2cEmployeeStateTotal(W2cDocument document)
            :base(document)
        {
            _record = new RcvRecord(document.Manager);
        }

        public void SetParent(W2cEmployer employer)
        {
            _parent = employer;

            if (employer != null)
                InternalRecord.SetParent(employer.InternalRecord);
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
            if (!base.Verify())
                return false;

            return true;
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
