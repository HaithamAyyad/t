using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFW2C.Extensions;

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

        public virtual void Prepare()
        {
            _record.Reset();
            _record.Prepare();

            foreach (var data in DataDictionary)
            {
                if (!string.IsNullOrWhiteSpace(data.Value))
                {
                    var dataValue = data.Value;

                    var fieldName = _mapPropFieldDictionary[data.Key];

                    var field = _record.CreateField(_record, fieldName, dataValue);

                    switch (field.FieldFormat)
                    {
                        case FieldFormat.Money:
                            dataValue = dataValue.Trim();

                            if (!IsValidMoneyFormat(dataValue))
                                throw new Exception($"{fieldName}: is not correct money field");

                            dataValue = ConvertMoneyToCent(dataValue);

                            field = _record.CreateField(_record, _mapPropFieldDictionary[data.Key], dataValue);

                            break;
                        case FieldFormat.Hyphen:
                            dataValue = dataValue.Replace("-", "");
                            field = _record.CreateField(_record, _mapPropFieldDictionary[data.Key], dataValue);
                            break;
                        case FieldFormat.Phone:
                            char[] charsToRemove = { ' ', '-', '(', ')' };
                            dataValue = charsToRemove.Aggregate(dataValue, (current, c) => current.Replace(c.ToString(), "")); field = _record.CreateField(_record, _mapPropFieldDictionary[data.Key], dataValue);
                            break;
                    }

                    _record.AddField(field);
                }
            }

            _record.Write();
        }

        static bool IsValidMoneyFormat(string input)
        {
            if (input.Count(c => c == '.') > 1)
                return false;

            if (!input.IsDigit(new char[] { ' ', ',', '.' }))
                return false;

            var parts = input.Split('.');
            var integerPart = parts[0];

            if (parts.Length > 1)
            {
                var decimalPart = parts[1];

                if (decimalPart.Length > 2)
                    return false;

                if (decimalPart.Length == 2)
                {
                    if (!char.IsDigit(decimalPart[0]))
                        return false;

                    if (!decimalPart[1].IsDigitOrSpace())
                        return false;
                }

                input = integerPart;
            }

            var commaParts = input.Split(',');

            for(var i = 1; i < commaParts.Length; i++)
            {
                if (commaParts[i].Length != 3)
                    return false;
            }

            return true;
        }
        private static string ConvertMoneyToCent(string dataValue)
        {
            // Remove commas and split into integer and decimal parts
            var parts = dataValue.Replace(",", "").Split('.');

            var integerPart = parts[0];

            var decimalPart = parts.Length > 1 ? parts[1].PadRight(2, '0') : "00";

            return integerPart + decimalPart;
        }

        protected void AddData(string value, [CallerMemberName] string propertyName = null)
        {
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
