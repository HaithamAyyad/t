using EFW2C.Fields;
using EFW2C.Manager;
using EFW2C.Records;
using System;
using System.Collections.Generic;
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
                _ein = value;
                AddData(value);
            }
        }

        private string _userID;
        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                AddData(value);
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

            mapDictionary.Add(nameof(W2cSubmitter.Ein), typeof(RcaEinSubmitterField).Name);
            mapDictionary.Add(nameof(W2cSubmitter.UserID), typeof(RcaUserIdentification).Name);

            return mapDictionary;
        }
    }
}