using EFW2C.Fields;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cEmployer : DocumentPart
    {
        private List<W2cEmployee> _employeeList;
        private W2cEmployeeStateTotal _employeeStateTotal;

        public List<W2cEmployee> EmployeeList { get { return _employeeList; } }
        public W2cEmployeeStateTotal EmployeeStateTotal { get { return _employeeStateTotal; } }
        internal RceRecord InternalRecord { get { return ((RceRecord)_record); } }

        public W2cEmployer(W2cDocument document)
            : base(document)
        {
            _record = new RceRecord(document.Manager);
            _employeeList = new List<W2cEmployee>();
        }

        public void AddEmployee(W2cEmployee employee)
        {
            if (employee != null)
            {
                employee.SetParent(this);
                InternalRecord.AddRcwRecord(employee.InternalRecord);

                _employeeList.Add(employee);
            }
        }

        public void SetEmployeeStateTotal(W2cEmployeeStateTotal employeeStateTotal)
        {
            if (_employeeStateTotal != null)
                _employeeStateTotal.SetParent(null);

            if (employeeStateTotal != null)
            {
                employeeStateTotal.SetParent(this);
                InternalRecord.SetRcvRecord(employeeStateTotal.InternalRecord);
            }

            _employeeStateTotal = employeeStateTotal;
        }

        private string _agentIndicator;
        public string AgentIndicator
        {
            get { return _agentIndicator; }
            set
            {
                if (_agentIndicator != value)
                {
                    _agentIndicator = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

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

        private string _einAgent;
        public string EinAgent
        {
            get { return _einAgent; }
            set
            {
                if (_einAgent != value)
                {
                    _einAgent = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _einAgentFederal;
        public string EinAgentFederal
        {
            get { return _einAgentFederal; }
            set
            {
                if (_einAgentFederal != value)
                {
                    _einAgentFederal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _einAgentFederalOriginal;
        public string EinAgentFederalOriginal
        {
            get { return _einAgentFederalOriginal; }
            set
            {
                if (_einAgentFederalOriginal != value)
                {
                    _einAgentFederalOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employerName;
        public string EmployerName
        {
            get { return _employerName; }
            set
            {
                if (_employerName != value)
                {
                    _employerName = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employmentCodeCorrect;
        public string EmploymentCodeCorrect
        {
            get { return _employmentCodeCorrect; }
            set
            {
                if (_employmentCodeCorrect != value)
                {
                    _employmentCodeCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employmentCodeOriginal;
        public string EmploymentCodeOriginal
        {
            get { return _employmentCodeOriginal; }
            set
            {
                if (_employmentCodeOriginal != value)
                {
                    _employmentCodeOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _establishmentNumberCorrect;
        public string EstablishmentNumberCorrect
        {
            get { return _establishmentNumberCorrect; }
            set
            {
                if (_establishmentNumberCorrect != value)
                {
                    _establishmentNumberCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _establishmentNumberOriginal;
        public string EstablishmentNumberOriginal
        {
            get { return _establishmentNumberOriginal; }
            set
            {
                if (_establishmentNumberOriginal != value)
                {
                    _establishmentNumberOriginal = value;
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


        private string _kindOfEmployer;
        public string KindOfEmployer
        {
            get { return _kindOfEmployer; }
            set
            {
                if (_kindOfEmployer != value)
                {
                    _kindOfEmployer = value;
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

        public void Reset()
        {
            _employeeList.Clear();
        }

        private string _taxYear;
        public string TaxYear
        {
            get { return _taxYear; }
            set
            {
                if (_taxYear != value)
                {
                    _taxYear = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _thirdPartySickPayCorrect;
        public string ThirdPartySickPayCorrect
        {
            get { return _thirdPartySickPayCorrect; }
            set
            {
                if (_thirdPartySickPayCorrect != value)
                {
                    _thirdPartySickPayCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _thirdPartySickPayOriginal;
        public string ThirdPartySickPayOriginal
        {
            get { return _thirdPartySickPayOriginal; }
            set
            {
                if (_thirdPartySickPayOriginal != value)
                {
                    _thirdPartySickPayOriginal = value;
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

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            foreach(var employee in _employeeList)
            {
                employee.Verify();
            }



            return true;
        }

        protected override Dictionary<string, string> CreateMapPropFieldDictionay()
        {
            var mapDictionary = new Dictionary<string, string>();

            mapDictionary.Add(nameof(AgentIndicator), typeof(RceAgentIndicator).Name);
            mapDictionary.Add(nameof(City), typeof(RceCity).Name);
            mapDictionary.Add(nameof(ContactEMailInternet), typeof(RceContactEMailInternet).Name);
            mapDictionary.Add(nameof(ContactFax), typeof(RceContactFax).Name);
            mapDictionary.Add(nameof(ContactName), typeof(RceContactName).Name);
            mapDictionary.Add(nameof(ContactPhone), typeof(RceContactPhone).Name);
            mapDictionary.Add(nameof(ContactPhoneExtension), typeof(RceContactPhoneExtension).Name);
            mapDictionary.Add(nameof(CountryCode), typeof(RceCountryCode).Name);
            mapDictionary.Add(nameof(DeliveryAddress), typeof(RceDeliveryAddress).Name);
            mapDictionary.Add(nameof(EinAgent), typeof(RceEinAgent).Name);
            mapDictionary.Add(nameof(EinAgentFederal), typeof(RceEinAgentFederal).Name);
            mapDictionary.Add(nameof(EinAgentFederalOriginal), typeof(RceEinAgentFederalOriginal).Name);
            mapDictionary.Add(nameof(EmployerName), typeof(RceEmployerName).Name);
            mapDictionary.Add(nameof(EmploymentCodeCorrect), typeof(RceEmploymentCodeCorrect).Name);
            mapDictionary.Add(nameof(EmploymentCodeOriginal), typeof(RceEmploymentCodeOriginal).Name);
            mapDictionary.Add(nameof(EstablishmentNumberCorrect), typeof(RceEstablishmentNumberCorrect).Name);
            mapDictionary.Add(nameof(EstablishmentNumberOriginal), typeof(RceEstablishmentNumberOriginal).Name);
            mapDictionary.Add(nameof(ForeignPostalCode), typeof(RceForeignPostalCode).Name);
            mapDictionary.Add(nameof(ForeignStateProvince), typeof(RceForeignStateProvince).Name);
            mapDictionary.Add(nameof(KindOfEmployer), typeof(RceKindOfEmployer).Name);
            mapDictionary.Add(nameof(LocationAddress), typeof(RceLocationAddress).Name);
            mapDictionary.Add(nameof(StateAbbreviation), typeof(RceStateAbbreviation).Name);
            mapDictionary.Add(nameof(TaxYear), typeof(RceTaxYear).Name);
            mapDictionary.Add(nameof(ThirdPartySickPayCorrect), typeof(RceThirdPartySickPayCorrect).Name);
            mapDictionary.Add(nameof(ThirdPartySickPayOriginal), typeof(RceThirdPartySickPayOriginal).Name);
            mapDictionary.Add(nameof(ZipCode), typeof(RceZipCode).Name);
            mapDictionary.Add(nameof(ZipCodeExtension), typeof(RceZipCodeExtension).Name);


            return mapDictionary;
        }
    }
}
