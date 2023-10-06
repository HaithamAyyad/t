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
        internal RcaRecord InternalRecord { get { return ((RcaRecord)_record); } }

        public W2cSubmitter(W2cDocument document)
            : base(document)
        {
            _record = new RcaRecord(document.Manager);
        }

        #region Properties
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _contactEMailInternet;
        public string ContactEMailInternet
        {
            get { return _contactEMailInternet; }
            set
            {
                if (_contactEMailInternet != value)
                {
                    _contactEMailInternet = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _contactFax;
        public string ContactFax
        {
            get { return _contactFax; }
            set
            {
                if (_contactFax != value)
                {
                    _contactFax = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _contactName;
        public string ContactName
        {
            get { return _contactName; }
            set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _contactPhone;
        public string ContactPhone
        {
            get { return _contactPhone; }
            set
            {
                if (_contactPhone != value)
                {
                    _contactPhone = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _contactPhoneExtension;
        public string ContactPhoneExtension
        {
            get { return _contactPhoneExtension; }
            set
            {
                if (_contactPhoneExtension != value)
                {
                    _contactPhoneExtension = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _countryCode;
        public string CountryCode
        {
            get { return _countryCode; }
            set
            {
                if (_countryCode != value)
                {
                    _countryCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deliveryAddress;
        public string DeliveryAddress
        {
            get { return _deliveryAddress; }
            set
            {
                if (_deliveryAddress != value)
                {
                    _deliveryAddress = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _einSubmitter;
        public string EinSubmitter
        {
            get { return _einSubmitter; }
            set
            {
                if (_einSubmitter != value)
                {
                    _einSubmitter = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _foreignPostalCode;
        public string ForeignPostalCode
        {
            get { return _foreignPostalCode; }
            set
            {
                if (_foreignPostalCode != value)
                {
                    _foreignPostalCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _foreignStateProvince;
        public string ForeignStateProvince
        {
            get { return _foreignStateProvince; }
            set
            {
                if (_foreignStateProvince != value)
                {
                    _foreignStateProvince = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _locationAddress;
        public string LocationAddress
        {
            get { return _locationAddress; }
            set
            {
                if (_locationAddress != value)
                {
                    _locationAddress = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _preparerCode;
        public string PreparerCode
        {
            get { return _preparerCode; }
            set
            {
                if (_preparerCode != value)
                {
                    _preparerCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _resubIndicator;
        public string ResubIndicator
        {
            get { return _resubIndicator; }
            set
            {
                if (_resubIndicator != value)
                {
                    _resubIndicator = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _resubWageFile;
        public string ResubWageFile
        {
            get { return _resubWageFile; }
            set
            {
                if (_resubWageFile != value)
                {
                    _resubWageFile = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _softwareCode;
        public string SoftwareCode
        {
            get { return _softwareCode; }
            set
            {
                if (_softwareCode != value)
                {
                    _softwareCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _softwareVendorCode;
        public string SoftwareVendorCode
        {
            get { return _softwareVendorCode; }
            set
            {
                if (_softwareVendorCode != value)
                {
                    _softwareVendorCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateAbbreviation;
        public string StateAbbreviation
        {
            get { return _stateAbbreviation; }
            set
            {
                if (_stateAbbreviation != value)
                {
                    _stateAbbreviation = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _submitterName;
        public string SubmitterName
        {
            get { return _submitterName; }
            set
            {
                if (_submitterName != value)
                {
                    _submitterName = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _userIdentification;
        public string UserIdentification
        {
            get { return _userIdentification; }
            set
            {
                if (_userIdentification != value)
                {
                    _userIdentification = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _zipCodeExtension;
        public string ZipCodeExtension
        {
            get { return _zipCodeExtension; }
            set
            {
                if (_zipCodeExtension != value)
                {
                    _zipCodeExtension = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        protected override Dictionary<string, string> CreateMapPropFieldDictionay()
        {
            var mapDictionary = new Dictionary<string, string>();

            mapDictionary.Add(nameof(City), typeof(RcaCity).Name);
            mapDictionary.Add(nameof(ContactEMailInternet), typeof(RcaContactEMailInternet).Name);
            mapDictionary.Add(nameof(ContactFax), typeof(RcaContactFax).Name);
            mapDictionary.Add(nameof(ContactName), typeof(RcaContactName).Name);
            mapDictionary.Add(nameof(ContactPhone), typeof(RcaContactPhone).Name);
            mapDictionary.Add(nameof(ContactPhoneExtension), typeof(RcaContactPhoneExtension).Name);
            mapDictionary.Add(nameof(CountryCode), typeof(RcaCountryCode).Name);
            mapDictionary.Add(nameof(DeliveryAddress), typeof(RcaDeliveryAddress).Name);
            mapDictionary.Add(nameof(EinSubmitter), typeof(RcaEinSubmitter).Name);
            mapDictionary.Add(nameof(ForeignPostalCode), typeof(RcaForeignPostalCode).Name);
            mapDictionary.Add(nameof(ForeignStateProvince), typeof(RcaForeignStateProvince).Name);
            mapDictionary.Add(nameof(LocationAddress), typeof(RcaLocationAddress).Name);
            mapDictionary.Add(nameof(PreparerCode), typeof(RcaPreparerCode).Name);
            mapDictionary.Add(nameof(ResubIndicator), typeof(RcaResubIndicator).Name);
            mapDictionary.Add(nameof(ResubWageFile), typeof(RcaResubWageFile).Name);
            mapDictionary.Add(nameof(SoftwareCode), typeof(RcaSoftwareCode).Name);
            mapDictionary.Add(nameof(SoftwareVendorCode), typeof(RcaSoftwareVendorCode).Name);
            mapDictionary.Add(nameof(StateAbbreviation), typeof(RcaStateAbbreviation).Name);
            mapDictionary.Add(nameof(SubmitterName), typeof(RcaSubmitterName).Name);
            mapDictionary.Add(nameof(UserIdentification), typeof(RcaUserIdentification).Name);
            mapDictionary.Add(nameof(ZipCode), typeof(RcaZipCode).Name);
            mapDictionary.Add(nameof(ZipCodeExtension), typeof(RcaZipCodeExtension).Name);

            return mapDictionary;
        }
    }
}