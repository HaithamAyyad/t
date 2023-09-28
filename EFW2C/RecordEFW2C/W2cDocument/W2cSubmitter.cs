using EFW2C.Fields;
using EFW2C.Manager;
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
    public class W2cSubmitter : DocumentPart
    {
        public W2cSubmitter(W2cDocument document)
            : base(document)
        {
            _record = new RcaRecord(document.Manager);
        }

        private string _ein;
        public string Ein
        {
            get { return _ein; }
            set
            {
                if (_ein != value)
                {
                    _ein = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _userID;


        public string UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        public override bool Verify()
        {
            if (!_record.Verify())
                return false;

            return true;
        }

        protected override Dictionary<string, string> CreateMapPropFieldDictionay()
        {
            var mapDictionary = new Dictionary<string, string>();

            mapDictionary.Add(nameof(Ein), typeof(RcaEinSubmitterField).Name);
            mapDictionary.Add(nameof(UserID), typeof(RcaUserIdentification).Name);

            return mapDictionary;
        }
    }
}