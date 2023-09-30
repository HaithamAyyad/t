using EFW2C.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cState : DocumentPart
    {
        public W2cState(W2cDocument document)
            : base(document)
        {

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

        private string _dateFirstEmployedCorrect;
        public string DateFirstEmployedCorrect
        {
            get { return _dateFirstEmployedCorrect; }
            set
            {
                if (_dateFirstEmployedCorrect != value)
                {
                    _dateFirstEmployedCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _dateFirstEmployedOriginal;
        public string DateFirstEmployedOriginal
        {
            get { return _dateFirstEmployedOriginal; }
            set
            {
                if (_dateFirstEmployedOriginal != value)
                {
                    _dateFirstEmployedOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _dateOfSeparationCorrect;
        public string DateOfSeparationCorrect
        {
            get { return _dateOfSeparationCorrect; }
            set
            {
                if (_dateOfSeparationCorrect != value)
                {
                    _dateOfSeparationCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _dateOfSeparationOriginal;
        public string DateOfSeparationOriginal
        {
            get { return _dateOfSeparationOriginal; }
            set
            {
                if (_dateOfSeparationOriginal != value)
                {
                    _dateOfSeparationOriginal = value;
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

        private string _employeeFirstNameCorrect;
        public string EmployeeFirstNameCorrect
        {
            get { return _employeeFirstNameCorrect; }
            set
            {
                if (_employeeFirstNameCorrect != value)
                {
                    _employeeFirstNameCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employeeFirstNameOriginal;
        public string EmployeeFirstNameOriginal
        {
            get { return _employeeFirstNameOriginal; }
            set
            {
                if (_employeeFirstNameOriginal != value)
                {
                    _employeeFirstNameOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employeeLastNameCorrect;
        public string EmployeeLastNameCorrect
        {
            get { return _employeeLastNameCorrect; }
            set
            {
                if (_employeeLastNameCorrect != value)
                {
                    _employeeLastNameCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employeeLastNameOriginal;
        public string EmployeeLastNameOriginal
        {
            get { return _employeeLastNameOriginal; }
            set
            {
                if (_employeeLastNameOriginal != value)
                {
                    _employeeLastNameOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employeeMiddleNameCorrect;
        public string EmployeeMiddleNameCorrect
        {
            get { return _employeeMiddleNameCorrect; }
            set
            {
                if (_employeeMiddleNameCorrect != value)
                {
                    _employeeMiddleNameCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employeeMiddleNameOriginal;
        public string EmployeeMiddleNameOriginal
        {
            get { return _employeeMiddleNameOriginal; }
            set
            {
                if (_employeeMiddleNameOriginal != value)
                {
                    _employeeMiddleNameOriginal = value;
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

        private string _localTaxableWagesCorrect;
        public string LocalTaxableWagesCorrect
        {
            get { return _localTaxableWagesCorrect; }
            set
            {
                if (_localTaxableWagesCorrect != value)
                {
                    _localTaxableWagesCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _localTaxableWagesOriginal;
        public string LocalTaxableWagesOriginal
        {
            get { return _localTaxableWagesOriginal; }
            set
            {
                if (_localTaxableWagesOriginal != value)
                {
                    _localTaxableWagesOriginal = value;
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

        private string _numberOfWeeksWorkedCorrect;
        public string NumberOfWeeksWorkedCorrect
        {
            get { return _numberOfWeeksWorkedCorrect; }
            set
            {
                if (_numberOfWeeksWorkedCorrect != value)
                {
                    _numberOfWeeksWorkedCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _numberOfWeeksWorkedOriginal;
        public string NumberOfWeeksWorkedOriginal
        {
            get { return _numberOfWeeksWorkedOriginal; }
            set
            {
                if (_numberOfWeeksWorkedOriginal != value)
                {
                    _numberOfWeeksWorkedOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _optionalCode;
        public string OptionalCode
        {
            get { return _optionalCode; }
            set
            {
                if (_optionalCode != value)
                {
                    _optionalCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _otherStateData;
        public string OtherStateData
        {
            get { return _otherStateData; }
            set
            {
                if (_otherStateData != value)
                {
                    _otherStateData = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _reportingPeriodCorrect;
        public string ReportingPeriodCorrect
        {
            get { return _reportingPeriodCorrect; }
            set
            {
                if (_reportingPeriodCorrect != value)
                {
                    _reportingPeriodCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _reportingPeriodOriginal;
        public string ReportingPeriodOriginal
        {
            get { return _reportingPeriodOriginal; }
            set
            {
                if (_reportingPeriodOriginal != value)
                {
                    _reportingPeriodOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _socialSecurityNumberCorrect;
        public string SocialSecurityNumberCorrect
        {
            get { return _socialSecurityNumberCorrect; }
            set
            {
                if (_socialSecurityNumberCorrect != value)
                {
                    _socialSecurityNumberCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _socialSecurityNumberOriginal;
        public string SocialSecurityNumberOriginal
        {
            get { return _socialSecurityNumberOriginal; }
            set
            {
                if (_socialSecurityNumberOriginal != value)
                {
                    _socialSecurityNumberOriginal = value;
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

        private string _stateCode;
        public string StateCode
        {
            get { return _stateCode; }
            set
            {
                if (_stateCode != value)
                {
                    _stateCode = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateCodeIncomeTax;
        public string StateCodeIncomeTax
        {
            get { return _stateCodeIncomeTax; }
            set
            {
                if (_stateCodeIncomeTax != value)
                {
                    _stateCodeIncomeTax = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateControlNumberCorrect;
        public string StateControlNumberCorrect
        {
            get { return _stateControlNumberCorrect; }
            set
            {
                if (_stateControlNumberCorrect != value)
                {
                    _stateControlNumberCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateControlNumberOriginal;
        public string StateControlNumberOriginal
        {
            get { return _stateControlNumberOriginal; }
            set
            {
                if (_stateControlNumberOriginal != value)
                {
                    _stateControlNumberOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateEmployerAccountNumberCorrect;
        public string StateEmployerAccountNumberCorrect
        {
            get { return _stateEmployerAccountNumberCorrect; }
            set
            {
                if (_stateEmployerAccountNumberCorrect != value)
                {
                    _stateEmployerAccountNumberCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateEmployerAccountNumberOriginal;
        public string StateEmployerAccountNumberOriginal
        {
            get { return _stateEmployerAccountNumberOriginal; }
            set
            {
                if (_stateEmployerAccountNumberOriginal != value)
                {
                    _stateEmployerAccountNumberOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateIncomeTaxWithheldCorrect;
        public string StateIncomeTaxWithheldCorrect
        {
            get { return _stateIncomeTaxWithheldCorrect; }
            set
            {
                if (_stateIncomeTaxWithheldCorrect != value)
                {
                    _stateIncomeTaxWithheldCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateIncomeTaxWithheldOriginal;
        public string StateIncomeTaxWithheldOriginal
        {
            get { return _stateIncomeTaxWithheldOriginal; }
            set
            {
                if (_stateIncomeTaxWithheldOriginal != value)
                {
                    _stateIncomeTaxWithheldOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateQuarterlyUnemploymentInsuranceTotalWagesCorrect;
        public string StateQuarterlyUnemploymentInsuranceTotalWagesCorrect
        {
            get { return _stateQuarterlyUnemploymentInsuranceTotalWagesCorrect; }
            set
            {
                if (_stateQuarterlyUnemploymentInsuranceTotalWagesCorrect != value)
                {
                    _stateQuarterlyUnemploymentInsuranceTotalWagesCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateQuarterlyUnemploymentInsuranceTotalWagesOriginal;
        public string StateQuarterlyUnemploymentInsuranceTotalWagesOriginal
        {
            get { return _stateQuarterlyUnemploymentInsuranceTotalWagesOriginal; }
            set
            {
                if (_stateQuarterlyUnemploymentInsuranceTotalWagesOriginal != value)
                {
                    _stateQuarterlyUnemploymentInsuranceTotalWagesOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateTaxableWagesCorrect;
        public string StateTaxableWagesCorrect
        {
            get { return _stateTaxableWagesCorrect; }
            set
            {
                if (_stateTaxableWagesCorrect != value)
                {
                    _stateTaxableWagesCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _stateTaxableWagesOriginal;
        public string StateTaxableWagesOriginal
        {
            get { return _stateTaxableWagesOriginal; }
            set
            {
                if (_stateTaxableWagesOriginal != value)
                {
                    _stateTaxableWagesOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _supplementalData1;
        public string SupplementalData1
        {
            get { return _supplementalData1; }
            set
            {
                if (_supplementalData1 != value)
                {
                    _supplementalData1 = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _supplementalData2;
        public string SupplementalData2
        {
            get { return _supplementalData2; }
            set
            {
                if (_supplementalData2 != value)
                {
                    _supplementalData2 = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _taxingEntityCodeCorrect;
        public string TaxingEntityCodeCorrect
        {
            get { return _taxingEntityCodeCorrect; }
            set
            {
                if (_taxingEntityCodeCorrect != value)
                {
                    _taxingEntityCodeCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _taxingEntityCodeOriginal;
        public string TaxingEntityCodeOriginal
        {
            get { return _taxingEntityCodeOriginal; }
            set
            {
                if (_taxingEntityCodeOriginal != value)
                {
                    _taxingEntityCodeOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _taxTypeCodeCorrect;
        public string TaxTypeCodeCorrect
        {
            get { return _taxTypeCodeCorrect; }
            set
            {
                if (_taxTypeCodeCorrect != value)
                {
                    _taxTypeCodeCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _taxTypeCodeOriginal;
        public string TaxTypeCodeOriginal
        {
            get { return _taxTypeCodeOriginal; }
            set
            {
                if (_taxTypeCodeOriginal != value)
                {
                    _taxTypeCodeOriginal = value;
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
            throw new NotImplementedException();
        }
        protected override Dictionary<string, string> CreateMapPropFieldDictionay()
        {
            var mapDictionary = new Dictionary<string, string>();

            mapDictionary.Add(nameof(City), typeof(RcsCity).Name);
            mapDictionary.Add(nameof(CountryCode), typeof(RcsCountryCode).Name);
            mapDictionary.Add(nameof(DateFirstEmployedCorrect), typeof(RcsDateFirstEmployedCorrect).Name);
            mapDictionary.Add(nameof(DateFirstEmployedOriginal), typeof(RcsDateFirstEmployedOriginal).Name);
            mapDictionary.Add(nameof(DateOfSeparationCorrect), typeof(RcsDateOfSeparationCorrect).Name);
            mapDictionary.Add(nameof(DateOfSeparationOriginal), typeof(RcsDateOfSeparationOriginal).Name);
            mapDictionary.Add(nameof(DeliveryAddress), typeof(RcsDeliveryAddress).Name);
            mapDictionary.Add(nameof(EmployeeFirstNameCorrect), typeof(RcsEmployeeFirstNameCorrect).Name);
            mapDictionary.Add(nameof(EmployeeFirstNameOriginal), typeof(RcsEmployeeFirstNameOriginal).Name);
            mapDictionary.Add(nameof(EmployeeLastNameCorrect), typeof(RcsEmployeeLastNameCorrect).Name);
            mapDictionary.Add(nameof(EmployeeLastNameOriginal), typeof(RcsEmployeeLastNameOriginal).Name);
            mapDictionary.Add(nameof(EmployeeMiddleNameCorrect), typeof(RcsEmployeeMiddleNameCorrect).Name);
            mapDictionary.Add(nameof(EmployeeMiddleNameOriginal), typeof(RcsEmployeeMiddleNameOriginal).Name);
            mapDictionary.Add(nameof(ForeignPostalCode), typeof(RcsForeignPostalCode).Name);
            mapDictionary.Add(nameof(ForeignStateProvince), typeof(RcsForeignStateProvince).Name);
            mapDictionary.Add(nameof(RecordIdentifier), typeof(RcsRecordIdentifier).Name);
            mapDictionary.Add(nameof(LocalTaxableWagesCorrect), typeof(RcsLocalTaxableWagesCorrect).Name);
            mapDictionary.Add(nameof(LocalTaxableWagesOriginal), typeof(RcsLocalTaxableWagesOriginal).Name);
            mapDictionary.Add(nameof(LocationAddress), typeof(RcsLocationAddress).Name);
            mapDictionary.Add(nameof(NumberOfWeeksWorkedCorrect), typeof(RcsNumberOfWeeksWorkedCorrect).Name);
            mapDictionary.Add(nameof(NumberOfWeeksWorkedOriginal), typeof(RcsNumberOfWeeksWorkedOriginal).Name);
            mapDictionary.Add(nameof(OptionalCode), typeof(RcsOptionalCode).Name);
            mapDictionary.Add(nameof(OtherStateData), typeof(RcsOtherStateData).Name);
            mapDictionary.Add(nameof(ReportingPeriodCorrect), typeof(RcsReportingPeriodCorrect).Name);
            mapDictionary.Add(nameof(ReportingPeriodOriginal), typeof(RcsReportingPeriodOriginal).Name);
            mapDictionary.Add(nameof(SocialSecurityNumberCorrect), typeof(RcsSocialSecurityNumberCorrect).Name);
            mapDictionary.Add(nameof(SocialSecurityNumberOriginal), typeof(RcsSocialSecurityNumberOriginal).Name);
            mapDictionary.Add(nameof(StateAbbreviation), typeof(RcsStateAbbreviation).Name);
            mapDictionary.Add(nameof(StateCode), typeof(RcsStateCode).Name);
            mapDictionary.Add(nameof(StateCodeIncomeTax), typeof(RcsStateCodeIncomeTax).Name);
            mapDictionary.Add(nameof(StateControlNumberCorrect), typeof(RcsStateControlNumberCorrect).Name);
            mapDictionary.Add(nameof(StateControlNumberOriginal), typeof(RcsStateControlNumberOriginal).Name);
            mapDictionary.Add(nameof(StateEmployerAccountNumberCorrect), typeof(RcsStateEmployerAccountNumberCorrect).Name);
            mapDictionary.Add(nameof(StateEmployerAccountNumberOriginal), typeof(RcsStateEmployerAccountNumberOriginal).Name);
            mapDictionary.Add(nameof(StateIncomeTaxWithheldCorrect), typeof(RcsStateIncomeTaxWithheldCorrect).Name);
            mapDictionary.Add(nameof(StateIncomeTaxWithheldOriginal), typeof(RcsStateIncomeTaxWithheldOriginal).Name);
            mapDictionary.Add(nameof(StateQuarterlyUnemploymentInsuranceTotalWagesCorrect), typeof(RcsStateQuarterlyUnemploymentInsuranceTotalWagesCorrect).Name);
            mapDictionary.Add(nameof(StateQuarterlyUnemploymentInsuranceTotalWagesOriginal), typeof(RcsStateQuarterlyUnemploymentInsuranceTotalWagesOriginal).Name);
            mapDictionary.Add(nameof(StateTaxableWagesCorrect), typeof(RcsStateTaxableWagesCorrect).Name);
            mapDictionary.Add(nameof(StateTaxableWagesOriginal), typeof(RcsStateTaxableWagesOriginal).Name);
            mapDictionary.Add(nameof(SupplementalData1), typeof(RcsSupplementalData1).Name);
            mapDictionary.Add(nameof(SupplementalData2), typeof(RcsSupplementalData2).Name);
            mapDictionary.Add(nameof(TaxingEntityCodeCorrect), typeof(RcsTaxingEntityCodeCorrect).Name);
            mapDictionary.Add(nameof(TaxingEntityCodeOriginal), typeof(RcsTaxingEntityCodeOriginal).Name);
            mapDictionary.Add(nameof(TaxTypeCodeCorrect), typeof(RcsTaxTypeCodeCorrect).Name);
            mapDictionary.Add(nameof(TaxTypeCodeOriginal), typeof(RcsTaxTypeCodeOriginal).Name);
            mapDictionary.Add(nameof(ZipCode), typeof(RcsZipCode).Name);
            mapDictionary.Add(nameof(ZipCodeExtension), typeof(RcsZipCodeExtension).Name);

            return mapDictionary;
        }
    }
}
