using EFW2C.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cEmployeeOptional : DocumentPart
    {
        public W2cEmployeeOptional(W2cDocument document)
            : base(document)
        {

        }

        private string _aggregateDeferralsCodeHHCorrect;
        public string AggregateDeferralsCodeHHCorrect
        {
            get { return _aggregateDeferralsCodeHHCorrect; }
            set
            {
                if (_aggregateDeferralsCodeHHCorrect != value)
                {
                    _aggregateDeferralsCodeHHCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _aggregateDeferralsCodeHHOriginal;
        public string AggregateDeferralsCodeHHOriginal
        {
            get { return _aggregateDeferralsCodeHHOriginal; }
            set
            {
                if (_aggregateDeferralsCodeHHOriginal != value)
                {
                    _aggregateDeferralsCodeHHOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _allocatedTipsCorrect;
        public string AllocatedTipsCorrect
        {
            get { return _allocatedTipsCorrect; }
            set
            {
                if (_allocatedTipsCorrect != value)
                {
                    _allocatedTipsCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _allocatedTipsOriginal;
        public string AllocatedTipsOriginal
        {
            get { return _allocatedTipsOriginal; }
            set
            {
                if (_allocatedTipsOriginal != value)
                {
                    _allocatedTipsOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _designatedRothContributionsCodeEECorrect;
        public string DesignatedRothContributionsCodeEECorrect
        {
            get { return _designatedRothContributionsCodeEECorrect; }
            set
            {
                if (_designatedRothContributionsCodeEECorrect != value)
                {
                    _designatedRothContributionsCodeEECorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _designatedRothContributionsCodeEEOriginal;
        public string DesignatedRothContributionsCodeEEOriginal
        {
            get { return _designatedRothContributionsCodeEEOriginal; }
            set
            {
                if (_designatedRothContributionsCodeEEOriginal != value)
                {
                    _designatedRothContributionsCodeEEOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _identifierField;
        public string IdentifierField
        {
            get { return _identifierField; }
            set
            {
                if (_identifierField != value)
                {
                    _identifierField = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _incomeFromQualifiedEquityCodeGGCorrect;
        public string IncomeFromQualifiedEquityCodeGGCorrect
        {
            get { return _incomeFromQualifiedEquityCodeGGCorrect; }
            set
            {
                if (_incomeFromQualifiedEquityCodeGGCorrect != value)
                {
                    _incomeFromQualifiedEquityCodeGGCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _incomeFromQualifiedEquityCodeGGOriginal;
        public string IncomeFromQualifiedEquityCodeGGOriginal
        {
            get { return _incomeFromQualifiedEquityCodeGGOriginal; }
            set
            {
                if (_incomeFromQualifiedEquityCodeGGOriginal != value)
                {
                    _incomeFromQualifiedEquityCodeGGOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _incomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect;
        public string IncomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect
        {
            get { return _incomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect; }
            set
            {
                if (_incomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect != value)
                {
                    _incomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _incomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal;
        public string IncomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal
        {
            get { return _incomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal; }
            set
            {
                if (_incomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal != value)
                {
                    _incomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _medicalSavingsAccountCodeRCorrect;
        public string MedicalSavingsAccountCodeRCorrect
        {
            get { return _medicalSavingsAccountCodeRCorrect; }
            set
            {
                if (_medicalSavingsAccountCodeRCorrect != value)
                {
                    _medicalSavingsAccountCodeRCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _medicalSavingsAccountCodeROriginal;
        public string MedicalSavingsAccountCodeROriginal
        {
            get { return _medicalSavingsAccountCodeROriginal; }
            set
            {
                if (_medicalSavingsAccountCodeROriginal != value)
                {
                    _medicalSavingsAccountCodeROriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _qualifiedAdoptionExpensesCodeTCorrect;
        public string QualifiedAdoptionExpensesCodeTCorrect
        {
            get { return _qualifiedAdoptionExpensesCodeTCorrect; }
            set
            {
                if (_qualifiedAdoptionExpensesCodeTCorrect != value)
                {
                    _qualifiedAdoptionExpensesCodeTCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _qualifiedAdoptionExpensesCodeTOriginal;
        public string QualifiedAdoptionExpensesCodeTOriginal
        {
            get { return _qualifiedAdoptionExpensesCodeTOriginal; }
            set
            {
                if (_qualifiedAdoptionExpensesCodeTOriginal != value)
                {
                    _qualifiedAdoptionExpensesCodeTOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _simpleRetirementAccountCodeSCorrect;
        public string SimpleRetirementAccountCodeSCorrect
        {
            get { return _simpleRetirementAccountCodeSCorrect; }
            set
            {
                if (_simpleRetirementAccountCodeSCorrect != value)
                {
                    _simpleRetirementAccountCodeSCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _simpleRetirementAccountCodeSOriginal;
        public string SimpleRetirementAccountCodeSOriginal
        {
            get { return _simpleRetirementAccountCodeSOriginal; }
            set
            {
                if (_simpleRetirementAccountCodeSOriginal != value)
                {
                    _simpleRetirementAccountCodeSOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _uncollectedEmployeeTaxOnTipsCodesABCorrect;
        public string UncollectedEmployeeTaxOnTipsCodesABCorrect
        {
            get { return _uncollectedEmployeeTaxOnTipsCodesABCorrect; }
            set
            {
                if (_uncollectedEmployeeTaxOnTipsCodesABCorrect != value)
                {
                    _uncollectedEmployeeTaxOnTipsCodesABCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _uncollectedEmployeeTaxOnTipsCodesABOriginal;
        public string UncollectedEmployeeTaxOnTipsCodesABOriginal
        {
            get { return _uncollectedEmployeeTaxOnTipsCodesABOriginal; }
            set
            {
                if (_uncollectedEmployeeTaxOnTipsCodesABOriginal != value)
                {
                    _uncollectedEmployeeTaxOnTipsCodesABOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _uncollectedMedicareTaxCodeNCorrect;
        public string UncollectedMedicareTaxCodeNCorrect
        {
            get { return _uncollectedMedicareTaxCodeNCorrect; }
            set
            {
                if (_uncollectedMedicareTaxCodeNCorrect != value)
                {
                    _uncollectedMedicareTaxCodeNCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _uncollectedMedicareTaxCodeNOriginal;
        public string UncollectedMedicareTaxCodeNOriginal
        {
            get { return _uncollectedMedicareTaxCodeNOriginal; }
            set
            {
                if (_uncollectedMedicareTaxCodeNOriginal != value)
                {
                    _uncollectedMedicareTaxCodeNOriginal = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _uncollectedSocialSecurityOrRRTATaxCodeMCorrect;
        public string UncollectedSocialSecurityOrRRTATaxCodeMCorrect
        {
            get { return _uncollectedSocialSecurityOrRRTATaxCodeMCorrect; }
            set
            {
                if (_uncollectedSocialSecurityOrRRTATaxCodeMCorrect != value)
                {
                    _uncollectedSocialSecurityOrRRTATaxCodeMCorrect = value;
                    AddData(value);
                    OnPropertyChanged();
                }
            }
        }

        private string _uncollectedSocialSecurityOrRRTATaxCodeMOriginal;
        public string UncollectedSocialSecurityOrRRTATaxCodeMOriginal
        {
            get { return _uncollectedSocialSecurityOrRRTATaxCodeMOriginal; }
            set
            {
                if (_uncollectedSocialSecurityOrRRTATaxCodeMOriginal != value)
                {
                    _uncollectedSocialSecurityOrRRTATaxCodeMOriginal = value;
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

            mapDictionary.Add(nameof(AggregateDeferralsCodeHHCorrect), typeof(RcoAggregateDeferralsCodeHHCorrect).Name);
            mapDictionary.Add(nameof(AggregateDeferralsCodeHHOriginal), typeof(RcoAggregateDeferralsCodeHHOriginal).Name);
            mapDictionary.Add(nameof(AllocatedTipsCorrect), typeof(RcoAllocatedTipsCorrect).Name);
            mapDictionary.Add(nameof(AllocatedTipsOriginal), typeof(RcoAllocatedTipsOriginal).Name);
            mapDictionary.Add(nameof(DesignatedRothContributionsCodeEECorrect), typeof(RcoDesignatedRothContributionsCodeEECorrect).Name);
            mapDictionary.Add(nameof(DesignatedRothContributionsCodeEEOriginal), typeof(RcoDesignatedRothContributionsCodeEEOriginal).Name);
            mapDictionary.Add(nameof(IdentifierField), typeof(RcoIdentifierField).Name);
            mapDictionary.Add(nameof(IncomeFromQualifiedEquityCodeGGCorrect), typeof(RcoIncomeFromQualifiedEquityCodeGGCorrect).Name);
            mapDictionary.Add(nameof(IncomeFromQualifiedEquityCodeGGOriginal), typeof(RcoIncomeFromQualifiedEquityCodeGGOriginal).Name);
            mapDictionary.Add(nameof(IncomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect), typeof(RcoIncomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect).Name);
            mapDictionary.Add(nameof(IncomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal), typeof(RcoIncomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal).Name);
            mapDictionary.Add(nameof(MedicalSavingsAccountCodeRCorrect), typeof(RcoMedicalSavingsAccountCodeRCorrect).Name);
            mapDictionary.Add(nameof(MedicalSavingsAccountCodeROriginal), typeof(RcoMedicalSavingsAccountCodeROriginal).Name);
            mapDictionary.Add(nameof(QualifiedAdoptionExpensesCodeTCorrect), typeof(RcoQualifiedAdoptionExpensesCodeTCorrect).Name);
            mapDictionary.Add(nameof(QualifiedAdoptionExpensesCodeTOriginal), typeof(RcoQualifiedAdoptionExpensesCodeTOriginal).Name);
            mapDictionary.Add(nameof(SimpleRetirementAccountCodeSCorrect), typeof(RcoSimpleRetirementAccountCodeSCorrect).Name);
            mapDictionary.Add(nameof(SimpleRetirementAccountCodeSOriginal), typeof(RcoSimpleRetirementAccountCodeSOriginal).Name);
            mapDictionary.Add(nameof(UncollectedEmployeeTaxOnTipsCodesABCorrect), typeof(RcoUncollectedEmployeeTaxOnTipsCodesABCorrect).Name);
            mapDictionary.Add(nameof(UncollectedEmployeeTaxOnTipsCodesABOriginal), typeof(RcoUncollectedEmployeeTaxOnTipsCodesABOriginal).Name);
            mapDictionary.Add(nameof(UncollectedMedicareTaxCodeNCorrect), typeof(RcoUncollectedMedicareTaxCodeNCorrect).Name);
            mapDictionary.Add(nameof(UncollectedMedicareTaxCodeNOriginal), typeof(RcoUncollectedMedicareTaxCodeNOriginal).Name);
            mapDictionary.Add(nameof(UncollectedSocialSecurityOrRRTATaxCodeMCorrect), typeof(RcoUncollectedSocialSecurityOrRRTATaxCodeMCorrect).Name);
            mapDictionary.Add(nameof(UncollectedSocialSecurityOrRRTATaxCodeMOriginal), typeof(RcoUncollectedSocialSecurityOrRRTATaxCodeMOriginal).Name);

            return mapDictionary;
        }
    }
}
