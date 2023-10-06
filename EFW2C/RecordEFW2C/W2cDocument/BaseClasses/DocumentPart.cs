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
                    }

                    _record.AddField(field);
                }
            }

            _record.Write();
        }

        static bool IsValidMoneyFormat(string input)
        {
            if (!(!input.Contains(".") && !input.Contains(",")))
            {
                var dotCount = input.Split('.').Length - 1;

                if (dotCount > 1)
                    return false;

                if (dotCount == 1)
                {
                    var parts = input.Split('.');
                    var integerPart = parts[0];
                    var decimalPart = parts[1];

                    if (integerPart.Length > 3 && integerPart.Length % 3 != 0)
                        return false;

                    if (decimalPart.Contains(","))
                        return false;
                }
                else
                {
                    if (input.Length > 3 && input.Length % 3 != 0)
                        return false;
                }
            }

            input = ConvertMoneyToCent(input);

            return input.All(char.IsDigit); ;
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
