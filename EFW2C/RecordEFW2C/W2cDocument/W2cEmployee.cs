using EFW2C.Fields;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cEmployee : DocumentPart
    {
        private W2cEmployer _parent;
        private W2cEmployeeOptional _employeeOptional;
        private W2cEmployeeState _employeeState;
        public W2cEmployeeOptional EmployeeOptional { get { return _employeeOptional; } }
        public W2cEmployeeState EmployeeState { get { return _employeeState; } }
        public W2cEmployer Parent { get { return _parent; } }
        internal RcwRecord InternalRecord { get { return ((RcwRecord)_record); } }

        public W2cEmployee(W2cDocument document)
            :base(document)
        {
            _record = new RcwRecord(document.Manager);
        }

        public void SetParent(W2cEmployer employer)
        {
            _parent = employer;
            if (employer != null)
                InternalRecord.SetParent((RceRecord)employer.Record);
        }

        public void SetEmployeeOptional(W2cEmployeeOptional employeeOptional)
        {
            if (_employeeOptional != null)
                _employeeOptional.SetParent(null);

            if (employeeOptional != null)
            {
                employeeOptional.SetParent(this);
                InternalRecord.SetRcoRecord(employeeOptional.InternalRecord);
            }

            _employeeOptional = employeeOptional;
        }

        public void SetEmployeeState(W2cEmployeeState employeeState)
        {
            if (_employeeState != null)
                _employeeState.SetParent(null);

            if (employeeState != null)
            {
                employeeState.SetParent(this);
                InternalRecord.SetRcsRecord(employeeState.InternalRecord);
            }

            _employeeState = employeeState;
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

        private string _costOfEmployerSponsoredHealthCoverageCodeDDCorrect;
        public string CostOfEmployerSponsoredHealthCoverageCodeDDCorrect
        {
            get { return _costOfEmployerSponsoredHealthCoverageCodeDDCorrect; }
            set
            {
                if (_costOfEmployerSponsoredHealthCoverageCodeDDCorrect != value)
                {
                    _costOfEmployerSponsoredHealthCoverageCodeDDCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _costOfEmployerSponsoredHealthCoverageCodeDDOriginal;
        public string CostOfEmployerSponsoredHealthCoverageCodeDDOriginal
        {
            get { return _costOfEmployerSponsoredHealthCoverageCodeDDOriginal; }
            set
            {
                if (_costOfEmployerSponsoredHealthCoverageCodeDDOriginal != value)
                {
                    _costOfEmployerSponsoredHealthCoverageCodeDDOriginal = value;
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

        private string _deferredCompensationCodeDCorrect;
        public string DeferredCompensationCodeDCorrect
        {
            get { return _deferredCompensationCodeDCorrect; }
            set
            {
                if (_deferredCompensationCodeDCorrect != value)
                {
                    _deferredCompensationCodeDCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeDOriginal;
        public string DeferredCompensationCodeDOriginal
        {
            get { return _deferredCompensationCodeDOriginal; }
            set
            {
                if (_deferredCompensationCodeDOriginal != value)
                {
                    _deferredCompensationCodeDOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeECorrect;
        public string DeferredCompensationCodeECorrect
        {
            get { return _deferredCompensationCodeECorrect; }
            set
            {
                if (_deferredCompensationCodeECorrect != value)
                {
                    _deferredCompensationCodeECorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeEOriginal;
        public string DeferredCompensationCodeEOriginal
        {
            get { return _deferredCompensationCodeEOriginal; }
            set
            {
                if (_deferredCompensationCodeEOriginal != value)
                {
                    _deferredCompensationCodeEOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeFCorrect;
        public string DeferredCompensationCodeFCorrect
        {
            get { return _deferredCompensationCodeFCorrect; }
            set
            {
                if (_deferredCompensationCodeFCorrect != value)
                {
                    _deferredCompensationCodeFCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeFOriginal;
        public string DeferredCompensationCodeFOriginal
        {
            get { return _deferredCompensationCodeFOriginal; }
            set
            {
                if (_deferredCompensationCodeFOriginal != value)
                {
                    _deferredCompensationCodeFOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeGCorrect;
        public string DeferredCompensationCodeGCorrect
        {
            get { return _deferredCompensationCodeGCorrect; }
            set
            {
                if (_deferredCompensationCodeGCorrect != value)
                {
                    _deferredCompensationCodeGCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeGOriginal;
        public string DeferredCompensationCodeGOriginal
        {
            get { return _deferredCompensationCodeGOriginal; }
            set
            {
                if (_deferredCompensationCodeGOriginal != value)
                {
                    _deferredCompensationCodeGOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeHCorrect;
        public string DeferredCompensationCodeHCorrect
        {
            get { return _deferredCompensationCodeHCorrect; }
            set
            {
                if (_deferredCompensationCodeHCorrect != value)
                {
                    _deferredCompensationCodeHCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _deferredCompensationCodeHOriginal;
        public string DeferredCompensationCodeHOriginal
        {
            get { return _deferredCompensationCodeHOriginal; }
            set
            {
                if (_deferredCompensationCodeHOriginal != value)
                {
                    _deferredCompensationCodeHOriginal = value;
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

        private string _dependentCareBenefitsCorrect;
        public string DependentCareBenefitsCorrect
        {
            get { return _dependentCareBenefitsCorrect; }
            set
            {
                if (_dependentCareBenefitsCorrect != value)
                {
                    _dependentCareBenefitsCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _dependentCareBenefitsOriginal;
        public string DependentCareBenefitsOriginal
        {
            get { return _dependentCareBenefitsOriginal; }
            set
            {
                if (_dependentCareBenefitsOriginal != value)
                {
                    _dependentCareBenefitsOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _designatedRothCodeAACorrect;
        public string DesignatedRothCodeAACorrect
        {
            get { return _designatedRothCodeAACorrect; }
            set
            {
                if (_designatedRothCodeAACorrect != value)
                {
                    _designatedRothCodeAACorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _designatedRothCodeAAOriginal;
        public string DesignatedRothCodeAAOriginal
        {
            get { return _designatedRothCodeAAOriginal; }
            set
            {
                if (_designatedRothCodeAAOriginal != value)
                {
                    _designatedRothCodeAAOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _designatedRothCodeBBCorrect;
        public string DesignatedRothCodeBBCorrect
        {
            get { return _designatedRothCodeBBCorrect; }
            set
            {
                if (_designatedRothCodeBBCorrect != value)
                {
                    _designatedRothCodeBBCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _designatedRothCodeBBOriginal;
        public string DesignatedRothCodeBBOriginal
        {
            get { return _designatedRothCodeBBOriginal; }
            set
            {
                if (_designatedRothCodeBBOriginal != value)
                {
                    _designatedRothCodeBBOriginal = value;
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

        private string _employerContributionsToSHealthSavingsAccountCodeWCorrect;
        public string EmployerContributionsToSHealthSavingsAccountCodeWCorrect
        {
            get { return _employerContributionsToSHealthSavingsAccountCodeWCorrect; }
            set
            {
                if (_employerContributionsToSHealthSavingsAccountCodeWCorrect != value)
                {
                    _employerContributionsToSHealthSavingsAccountCodeWCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employerContributionsToSHealthSavingsAccountCodeWOriginal;
        public string EmployerContributionsToSHealthSavingsAccountCodeWOriginal
        {
            get { return _employerContributionsToSHealthSavingsAccountCodeWOriginal; }
            set
            {
                if (_employerContributionsToSHealthSavingsAccountCodeWOriginal != value)
                {
                    _employerContributionsToSHealthSavingsAccountCodeWOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employerCostOfPremiumsCodeCCorrect;
        public string EmployerCostOfPremiumsCodeCCorrect
        {
            get { return _employerCostOfPremiumsCodeCCorrect; }
            set
            {
                if (_employerCostOfPremiumsCodeCCorrect != value)
                {
                    _employerCostOfPremiumsCodeCCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _employerCostOfPremiumsCodeCOriginal;
        public string EmployerCostOfPremiumsCodeCOriginal
        {
            get { return _employerCostOfPremiumsCodeCOriginal; }
            set
            {
                if (_employerCostOfPremiumsCodeCOriginal != value)
                {
                    _employerCostOfPremiumsCodeCOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _federalIncomeTaxWithheldCorrect;
        public string FederalIncomeTaxWithheldCorrect
        {
            get { return _federalIncomeTaxWithheldCorrect; }
            set
            {
                if (_federalIncomeTaxWithheldCorrect != value)
                {
                    _federalIncomeTaxWithheldCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _federalIncomeTaxWithheldOriginal;
        public string FederalIncomeTaxWithheldOriginal
        {
            get { return _federalIncomeTaxWithheldOriginal; }
            set
            {
                if (_federalIncomeTaxWithheldOriginal != value)
                {
                    _federalIncomeTaxWithheldOriginal = value;
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

        private string _incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect;
        public string IncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect
        {
            get { return _incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect; }
            set
            {
                if (_incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect != value)
                {
                    _incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal;
        public string IncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal
        {
            get { return _incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal; }
            set
            {
                if (_incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal != value)
                {
                    _incomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal = value;
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

        private string _medicareTaxWithheldCorrect;
        public string MedicareTaxWithheldCorrect
        {
            get { return _medicareTaxWithheldCorrect; }
            set
            {
                if (_medicareTaxWithheldCorrect != value)
                {
                    _medicareTaxWithheldCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _medicareTaxWithheldOriginal;
        public string MedicareTaxWithheldOriginal
        {
            get { return _medicareTaxWithheldOriginal; }
            set
            {
                if (_medicareTaxWithheldOriginal != value)
                {
                    _medicareTaxWithheldOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _medicareWagesAndTipsCorrect;
        public string MedicareWagesAndTipsCorrect
        {
            get { return _medicareWagesAndTipsCorrect; }
            set
            {
                if (_medicareWagesAndTipsCorrect != value)
                {
                    _medicareWagesAndTipsCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _medicareWagesAndTipsOriginal;
        public string MedicareWagesAndTipsOriginal
        {
            get { return _medicareWagesAndTipsOriginal; }
            set
            {
                if (_medicareWagesAndTipsOriginal != value)
                {
                    _medicareWagesAndTipsOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _middleNameEmployeeCorrect;
        public string MiddleNameEmployeeCorrect
        {
            get { return _middleNameEmployeeCorrect; }
            set
            {
                if (_middleNameEmployeeCorrect != value)
                {
                    _middleNameEmployeeCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _middleNameEmployeeOriginal;
        public string MiddleNameEmployeeOriginal
        {
            get { return _middleNameEmployeeOriginal; }
            set
            {
                if (_middleNameEmployeeOriginal != value)
                {
                    _middleNameEmployeeOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nonQualifiedDeferredCompensationPlanCodeYCorrect;
        public string NonQualifiedDeferredCompensationPlanCodeYCorrect
        {
            get { return _nonQualifiedDeferredCompensationPlanCodeYCorrect; }
            set
            {
                if (_nonQualifiedDeferredCompensationPlanCodeYCorrect != value)
                {
                    _nonQualifiedDeferredCompensationPlanCodeYCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nonQualifiedDeferredCompensationPlanCodeYOriginal;
        public string NonQualifiedDeferredCompensationPlanCodeYOriginal
        {
            get { return _nonQualifiedDeferredCompensationPlanCodeYOriginal; }
            set
            {
                if (_nonQualifiedDeferredCompensationPlanCodeYOriginal != value)
                {
                    _nonQualifiedDeferredCompensationPlanCodeYOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nonQualifiedPlanNotSection457Correct;
        public string NonQualifiedPlanNotSection457Correct
        {
            get { return _nonQualifiedPlanNotSection457Correct; }
            set
            {
                if (_nonQualifiedPlanNotSection457Correct != value)
                {
                    _nonQualifiedPlanNotSection457Correct = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nonQualifiedPlanNotSection457Original;
        public string NonQualifiedPlanNotSection457Original
        {
            get { return _nonQualifiedPlanNotSection457Original; }
            set
            {
                if (_nonQualifiedPlanNotSection457Original != value)
                {
                    _nonQualifiedPlanNotSection457Original = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nonQualifiedPlanSection457Correct;
        public string NonQualifiedPlanSection457Correct
        {
            get { return _nonQualifiedPlanSection457Correct; }
            set
            {
                if (_nonQualifiedPlanSection457Correct != value)
                {
                    _nonQualifiedPlanSection457Correct = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nonQualifiedPlanSection457Original;
        public string NonQualifiedPlanSection457Original
        {
            get { return _nonQualifiedPlanSection457Original; }
            set
            {
                if (_nonQualifiedPlanSection457Original != value)
                {
                    _nonQualifiedPlanSection457Original = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nontaxableCombatPayCodeQCorrect;
        public string NontaxableCombatPayCodeQCorrect
        {
            get { return _nontaxableCombatPayCodeQCorrect; }
            set
            {
                if (_nontaxableCombatPayCodeQCorrect != value)
                {
                    _nontaxableCombatPayCodeQCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _nontaxableCombatPayCodeQOriginal;
        public string NontaxableCombatPayCodeQOriginal
        {
            get { return _nontaxableCombatPayCodeQOriginal; }
            set
            {
                if (_nontaxableCombatPayCodeQOriginal != value)
                {
                    _nontaxableCombatPayCodeQOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _permittedBenefitsUnderAQSEHRACodeFFCorrect;
        public string PermittedBenefitsUnderAQSEHRACodeFFCorrect
        {
            get { return _permittedBenefitsUnderAQSEHRACodeFFCorrect; }
            set
            {
                if (_permittedBenefitsUnderAQSEHRACodeFFCorrect != value)
                {
                    _permittedBenefitsUnderAQSEHRACodeFFCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _permittedBenefitsUnderAQSEHRACodeFFOriginal;
        public string PermittedBenefitsUnderAQSEHRACodeFFOriginal
        {
            get { return _permittedBenefitsUnderAQSEHRACodeFFOriginal; }
            set
            {
                if (_permittedBenefitsUnderAQSEHRACodeFFOriginal != value)
                {
                    _permittedBenefitsUnderAQSEHRACodeFFOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _retirementPlanIndicatorCorrect;
        public string RetirementPlanIndicatorCorrect
        {
            get { return _retirementPlanIndicatorCorrect; }
            set
            {
                if (_retirementPlanIndicatorCorrect != value)
                {
                    _retirementPlanIndicatorCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _retirementPlanIndicatorOriginal;
        public string RetirementPlanIndicatorOriginal
        {
            get { return _retirementPlanIndicatorOriginal; }
            set
            {
                if (_retirementPlanIndicatorOriginal != value)
                {
                    _retirementPlanIndicatorOriginal = value;
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

        private string _socialSecurityTaxWithheldCorrect;
        public string SocialSecurityTaxWithheldCorrect
        {
            get { return _socialSecurityTaxWithheldCorrect; }
            set
            {
                if (_socialSecurityTaxWithheldCorrect != value)
                {
                    _socialSecurityTaxWithheldCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _socialSecurityTaxWithheldOriginal;
        public string SocialSecurityTaxWithheldOriginal
        {
            get { return _socialSecurityTaxWithheldOriginal; }
            set
            {
                if (_socialSecurityTaxWithheldOriginal != value)
                {
                    _socialSecurityTaxWithheldOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _socialSecurityTipsCorrect;
        public string SocialSecurityTipsCorrect
        {
            get { return _socialSecurityTipsCorrect; }
            set
            {
                if (_socialSecurityTipsCorrect != value)
                {
                    _socialSecurityTipsCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _socialSecurityTipsOriginal;
        public string SocialSecurityTipsOriginal
        {
            get { return _socialSecurityTipsOriginal; }
            set
            {
                if (_socialSecurityTipsOriginal != value)
                {
                    _socialSecurityTipsOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _socialSecurityWagesCorrect;
        public string SocialSecurityWagesCorrect
        {
            get { return _socialSecurityWagesCorrect; }
            set
            {
                if (_socialSecurityWagesCorrect != value)
                {
                    _socialSecurityWagesCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _socialSecurityWagesOriginal;
        public string SocialSecurityWagesOriginal
        {
            get { return _socialSecurityWagesOriginal; }
            set
            {
                if (_socialSecurityWagesOriginal != value)
                {
                    _socialSecurityWagesOriginal = value;
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

        private string _statutoryEmployeeIndicatorCorrect;
        public string StatutoryEmployeeIndicatorCorrect
        {
            get { return _statutoryEmployeeIndicatorCorrect; }
            set
            {
                if (_statutoryEmployeeIndicatorCorrect != value)
                {
                    _statutoryEmployeeIndicatorCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _statutoryEmployeeIndicatorOriginal;
        public string StatutoryEmployeeIndicatorOriginal
        {
            get { return _statutoryEmployeeIndicatorOriginal; }
            set
            {
                if (_statutoryEmployeeIndicatorOriginal != value)
                {
                    _statutoryEmployeeIndicatorOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _thirdPartySickPayndicatorCorrect;
        public string ThirdPartySickPayndicatorCorrect
        {
            get { return _thirdPartySickPayndicatorCorrect; }
            set
            {
                if (_thirdPartySickPayndicatorCorrect != value)
                {
                    _thirdPartySickPayndicatorCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _thirdPartySickPayndicatorOriginal;
        public string ThirdPartySickPayndicatorOriginal
        {
            get { return _thirdPartySickPayndicatorOriginal; }
            set
            {
                if (_thirdPartySickPayndicatorOriginal != value)
                {
                    _thirdPartySickPayndicatorOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _totalDeferredCompensationContributionsCorrect;
        public string TotalDeferredCompensationContributionsCorrect
        {
            get { return _totalDeferredCompensationContributionsCorrect; }
            set
            {
                if (_totalDeferredCompensationContributionsCorrect != value)
                {
                    _totalDeferredCompensationContributionsCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _totalDeferredCompensationContributionsOriginal;
        public string TotalDeferredCompensationContributionsOriginal
        {
            get { return _totalDeferredCompensationContributionsOriginal; }
            set
            {
                if (_totalDeferredCompensationContributionsOriginal != value)
                {
                    _totalDeferredCompensationContributionsOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _wagesTipsAndOtherCompensationCorrect;
        public string WagesTipsAndOtherCompensationCorrect
        {
            get { return _wagesTipsAndOtherCompensationCorrect; }
            set
            {
                if (_wagesTipsAndOtherCompensationCorrect != value)
                {
                    _wagesTipsAndOtherCompensationCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _wagesTipsAndOtherCompensationOriginal;
        public string WagesTipsAndOtherCompensationOriginal
        {
            get { return _wagesTipsAndOtherCompensationOriginal; }
            set
            {
                if (_wagesTipsAndOtherCompensationOriginal != value)
                {
                    _wagesTipsAndOtherCompensationOriginal = value;
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

            return true;
        }

        protected override Dictionary<string, string> CreateMapPropFieldDictionay()
        {
            var mapDictionary = new Dictionary<string, string>();

            mapDictionary.Add(nameof(City), typeof(RcwCity).Name);
            mapDictionary.Add(nameof(CostOfEmployerSponsoredHealthCoverageCodeDDCorrect), typeof(RcwCostOfEmployerSponsoredHealthCoverageCodeDDCorrect).Name);
            mapDictionary.Add(nameof(CostOfEmployerSponsoredHealthCoverageCodeDDOriginal), typeof(RcwCostOfEmployerSponsoredHealthCoverageCodeDDOriginal).Name);
            mapDictionary.Add(nameof(CountryCode), typeof(RcwCountryCode).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeDCorrect), typeof(RcwDeferredCompensationCodeDCorrect).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeDOriginal), typeof(RcwDeferredCompensationCodeDOriginal).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeECorrect), typeof(RcwDeferredCompensationCodeECorrect).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeEOriginal), typeof(RcwDeferredCompensationCodeEOriginal).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeFCorrect), typeof(RcwDeferredCompensationCodeFCorrect).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeFOriginal), typeof(RcwDeferredCompensationCodeFOriginal).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeGCorrect), typeof(RcwDeferredCompensationCodeGCorrect).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeGOriginal), typeof(RcwDeferredCompensationCodeGOriginal).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeHCorrect), typeof(RcwDeferredCompensationCodeHCorrect).Name);
            mapDictionary.Add(nameof(DeferredCompensationCodeHOriginal), typeof(RcwDeferredCompensationCodeHOriginal).Name);
            mapDictionary.Add(nameof(DeliveryAddress), typeof(RcwDeliveryAddress).Name);
            mapDictionary.Add(nameof(DependentCareBenefitsCorrect), typeof(RcwDependentCareBenefitsCorrect).Name);
            mapDictionary.Add(nameof(DependentCareBenefitsOriginal), typeof(RcwDependentCareBenefitsOriginal).Name);
            mapDictionary.Add(nameof(DesignatedRothCodeAACorrect), typeof(RcwDesignatedRothCodeAACorrect).Name);
            mapDictionary.Add(nameof(DesignatedRothCodeAAOriginal), typeof(RcwDesignatedRothCodeAAOriginal).Name);
            mapDictionary.Add(nameof(DesignatedRothCodeBBCorrect), typeof(RcwDesignatedRothCodeBBCorrect).Name);
            mapDictionary.Add(nameof(DesignatedRothCodeBBOriginal), typeof(RcwDesignatedRothCodeBBOriginal).Name);
            mapDictionary.Add(nameof(EmployeeFirstNameCorrect), typeof(RcwEmployeeFirstNameCorrect).Name);
            mapDictionary.Add(nameof(EmployeeFirstNameOriginal), typeof(RcwEmployeeFirstNameOriginal).Name);
            mapDictionary.Add(nameof(EmployeeLastNameCorrect), typeof(RcwEmployeeLastNameCorrect).Name);
            mapDictionary.Add(nameof(EmployeeLastNameOriginal), typeof(RcwEmployeeLastNameOriginal).Name);
            mapDictionary.Add(nameof(EmployerContributionsToSHealthSavingsAccountCodeWCorrect), typeof(RcwEmployerContributionsToSHealthSavingsAccountCodeWCorrect).Name);
            mapDictionary.Add(nameof(EmployerContributionsToSHealthSavingsAccountCodeWOriginal), typeof(RcwEmployerContributionsToSHealthSavingsAccountCodeWOriginal).Name);
            mapDictionary.Add(nameof(EmployerCostOfPremiumsCodeCCorrect), typeof(RcwEmployerCostOfPremiumsCodeCCorrect).Name);
            mapDictionary.Add(nameof(EmployerCostOfPremiumsCodeCOriginal), typeof(RcwEmployerCostOfPremiumsCodeCOriginal).Name);
            mapDictionary.Add(nameof(FederalIncomeTaxWithheldCorrect), typeof(RcwFederalIncomeTaxWithheldCorrect).Name);
            mapDictionary.Add(nameof(FederalIncomeTaxWithheldOriginal), typeof(RcwFederalIncomeTaxWithheldOriginal).Name);
            mapDictionary.Add(nameof(ForeignPostalCode), typeof(RcwForeignPostalCode).Name);
            mapDictionary.Add(nameof(ForeignStateProvince), typeof(RcwForeignStateProvince).Name);
            mapDictionary.Add(nameof(RecordIdentifier), typeof(RcwRecordIdentifier).Name);
            mapDictionary.Add(nameof(IncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect), typeof(RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect).Name);
            mapDictionary.Add(nameof(IncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal), typeof(RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal).Name);
            mapDictionary.Add(nameof(LocationAddress), typeof(RcwLocationAddress).Name);
            mapDictionary.Add(nameof(MedicareTaxWithheldCorrect), typeof(RcwMedicareTaxWithheldCorrect).Name);
            mapDictionary.Add(nameof(MedicareTaxWithheldOriginal), typeof(RcwMedicareTaxWithheldOriginal).Name);
            mapDictionary.Add(nameof(MedicareWagesAndTipsCorrect), typeof(RcwMedicareWagesAndTipsCorrect).Name);
            mapDictionary.Add(nameof(MedicareWagesAndTipsOriginal), typeof(RcwMedicareWagesAndTipsOriginal).Name);
            mapDictionary.Add(nameof(MiddleNameEmployeeCorrect), typeof(RcwMiddleNameEmployeeCorrect).Name);
            mapDictionary.Add(nameof(MiddleNameEmployeeOriginal), typeof(RcwMiddleNameEmployeeOriginal).Name);
            mapDictionary.Add(nameof(NonQualifiedDeferredCompensationPlanCodeYCorrect), typeof(RcwNonQualifiedDeferredCompensationPlanCodeYCorrect).Name);
            mapDictionary.Add(nameof(NonQualifiedDeferredCompensationPlanCodeYOriginal), typeof(RcwNonQualifiedDeferredCompensationPlanCodeYOriginal).Name);
            mapDictionary.Add(nameof(NonQualifiedPlanNotSection457Correct), typeof(RcwNonQualifiedPlanNotSection457Correct).Name);
            mapDictionary.Add(nameof(NonQualifiedPlanNotSection457Original), typeof(RcwNonQualifiedPlanNotSection457Original).Name);
            mapDictionary.Add(nameof(NonQualifiedPlanSection457Correct), typeof(RcwNonQualifiedPlanSection457Correct).Name);
            mapDictionary.Add(nameof(NonQualifiedPlanSection457Original), typeof(RcwNonQualifiedPlanSection457Original).Name);
            mapDictionary.Add(nameof(NontaxableCombatPayCodeQCorrect), typeof(RcwNontaxableCombatPayCodeQCorrect).Name);
            mapDictionary.Add(nameof(NontaxableCombatPayCodeQOriginal), typeof(RcwNontaxableCombatPayCodeQOriginal).Name);
            mapDictionary.Add(nameof(PermittedBenefitsUnderAQSEHRACodeFFCorrect), typeof(RcwPermittedBenefitsUnderAQSEHRACodeFFCorrect).Name);
            mapDictionary.Add(nameof(PermittedBenefitsUnderAQSEHRACodeFFOriginal), typeof(RcwPermittedBenefitsUnderAQSEHRACodeFFOriginal).Name);
            mapDictionary.Add(nameof(RetirementPlanIndicatorCorrect), typeof(RcwRetirementPlanIndicatorCorrect).Name);
            mapDictionary.Add(nameof(RetirementPlanIndicatorOriginal), typeof(RcwRetirementPlanIndicatorOriginal).Name);
            mapDictionary.Add(nameof(SocialSecurityNumberCorrect), typeof(RcwSocialSecurityNumberCorrect).Name);
            mapDictionary.Add(nameof(SocialSecurityNumberOriginal), typeof(RcwSocialSecurityNumberOriginal).Name);
            mapDictionary.Add(nameof(SocialSecurityTaxWithheldCorrect), typeof(RcwSocialSecurityTaxWithheldCorrect).Name);
            mapDictionary.Add(nameof(SocialSecurityTaxWithheldOriginal), typeof(RcwSocialSecurityTaxWithheldOriginal).Name);
            mapDictionary.Add(nameof(SocialSecurityTipsCorrect), typeof(RcwSocialSecurityTipsCorrect).Name);
            mapDictionary.Add(nameof(SocialSecurityTipsOriginal), typeof(RcwSocialSecurityTipsOriginal).Name);
            mapDictionary.Add(nameof(SocialSecurityWagesCorrect), typeof(RcwSocialSecurityWagesCorrect).Name);
            mapDictionary.Add(nameof(SocialSecurityWagesOriginal), typeof(RcwSocialSecurityWagesOriginal).Name);
            mapDictionary.Add(nameof(StateAbbreviation), typeof(RcwStateAbbreviation).Name);
            mapDictionary.Add(nameof(StatutoryEmployeeIndicatorCorrect), typeof(RcwStatutoryEmployeeIndicatorCorrect).Name);
            mapDictionary.Add(nameof(StatutoryEmployeeIndicatorOriginal), typeof(RcwStatutoryEmployeeIndicatorOriginal).Name);
            mapDictionary.Add(nameof(ThirdPartySickPayndicatorCorrect), typeof(RcwThirdPartySickPayndicatorCorrect).Name);
            mapDictionary.Add(nameof(ThirdPartySickPayndicatorOriginal), typeof(RcwThirdPartySickPayndicatorOriginal).Name);
            mapDictionary.Add(nameof(TotalDeferredCompensationContributionsCorrect), typeof(RcwTotalDeferredCompensationContributionsCorrect).Name);
            mapDictionary.Add(nameof(TotalDeferredCompensationContributionsOriginal), typeof(RcwTotalDeferredCompensationContributionsOriginal).Name);
            mapDictionary.Add(nameof(WagesTipsAndOtherCompensationCorrect), typeof(RcwWagesTipsAndOtherCompensationCorrect).Name);
            mapDictionary.Add(nameof(WagesTipsAndOtherCompensationOriginal), typeof(RcwWagesTipsAndOtherCompensationOriginal).Name);
            mapDictionary.Add(nameof(ZipCode), typeof(RcwZipCode).Name);
            mapDictionary.Add(nameof(ZipCodeExtension), typeof(RcwZipCodeExtension).Name);

            return mapDictionary;
        }
    }
}
