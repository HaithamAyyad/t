using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RcwRecord : RecordBase
    {
        private RceRecord _parent;
        private RcoRecord _rcoRecord;
        private RcsRecord _rcsRecord;

        public RcoRecord RcoRecord { get { return _rcoRecord; } }
        public RcsRecord RcsRecord { get { return _rcsRecord; } }
        public RceRecord Parent { get { return _parent; } }

        public RcwRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcw.ToString())
        {
            Prepare();
        }

        public RcwRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcw.ToString(), buffer)
        {
            Prepare();
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcwRecord = new RcwRecord(manager);

            if (_rcoRecord != null)
                rcwRecord.SetRcoRecord((RcoRecord)_rcoRecord.Clone(manager));

            if (_rcsRecord != null)
                rcwRecord.SetRcsRecord((RcsRecord)_rcsRecord.Clone(manager));

            CloneData(rcwRecord);

            return rcwRecord;
        }

        public void SetParent(RceRecord parent)
        {
            _parent = parent;
        }

        public void SetRcoRecord(RcoRecord rcoRecord)
        {
            if (_rcoRecord != null)
                _rcoRecord.SetParent(null);

            _rcoRecord = rcoRecord;

            if (rcoRecord != null)
                _rcoRecord.SetParent(this);
        }

        public void SetRcsRecord(RcsRecord rcsRecord)
        {
            if (_rcsRecord != null)
                _rcsRecord.SetParent(null);

            _rcsRecord = rcsRecord;

            if (rcsRecord != null)
                _rcsRecord.SetParent(this);
        }

        public override bool Verify()
        {
            if(_parent == null)
                throw new Exception($"Employee : must be added to Employer");

            if (_rcoRecord != null)
            {
                if (!_rcoRecord.Verify())
                    return false;
            }

            if (_rcsRecord != null)
            {
                if (!_rcsRecord.Verify())
                    return false;
            }

            return base.Verify();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (198, 5),
                (397, 22),
                (573, 22),
                (683, 22),
                (859, 143),
                (1008, 16),
            };
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcwCity(this, "Helper"),
                new RcwCostOfEmployerSponsoredHealthCoverageCodeDDCorrect(this, "Helper"),
                new RcwCostOfEmployerSponsoredHealthCoverageCodeDDOriginal(this, "Helper"),
                new RcwCountryCode(this, "Helper"),
                new RcwDeferredCompensationCodeDCorrect(this, "Helper"),
                new RcwDeferredCompensationCodeDOriginal(this, "Helper"),
                new RcwDeferredCompensationCodeECorrect(this, "Helper"),
                new RcwDeferredCompensationCodeEOriginal(this, "Helper"),
                new RcwDeferredCompensationCodeFCorrect(this, "Helper"),
                new RcwDeferredCompensationCodeFOriginal(this, "Helper"),
                new RcwDeferredCompensationCodeGCorrect(this, "Helper"),
                new RcwDeferredCompensationCodeGOriginal(this, "Helper"),
                new RcwDeferredCompensationCodeHCorrect(this, "Helper"),
                new RcwDeferredCompensationCodeHOriginal(this, "Helper"),
                new RcwDeliveryAddress(this, "Helper"),
                new RcwDependentCareBenefitsCorrect(this, "Helper"),
                new RcwDependentCareBenefitsOriginal(this, "Helper"),
                new RcwDesignatedRothCodeAACorrect(this, "Helper"),
                new RcwDesignatedRothCodeAAOriginal(this, "Helper"),
                new RcwDesignatedRothCodeBBCorrect(this, "Helper"),
                new RcwDesignatedRothCodeBBOriginal(this, "Helper"),
                new RcwEmployeeFirstNameCorrect(this, "Helper"),
                new RcwEmployeeFirstNameOriginal(this, "Helper"),
                new RcwEmployeeLastNameCorrect(this, "Helper"),
                new RcwEmployeeLastNameOriginal(this, "Helper"),
                new RcwEmployerContributionsToSHealthSavingsAccountCodeWCorrect(this, "Helper"),
                new RcwEmployerContributionsToSHealthSavingsAccountCodeWOriginal(this, "Helper"),
                new RcwEmployerCostOfPremiumsCodeCCorrect(this, "Helper"),
                new RcwEmployerCostOfPremiumsCodeCOriginal(this, "Helper"),
                new RcwFederalIncomeTaxWithheldCorrect(this, "Helper"),
                new RcwFederalIncomeTaxWithheldOriginal(this, "Helper"),
                new RcwForeignPostalCode(this, "Helper"),
                new RcwForeignStateProvince(this, "Helper"),
                new RcwRecordIdentifier(this),
                new RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect(this, "Helper"),
                new RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal(this, "Helper"),
                new RcwLocationAddress(this, "Helper"),
                new RcwMedicareTaxWithheldCorrect(this, "Helper"),
                new RcwMedicareTaxWithheldOriginal(this, "Helper"),
                new RcwMedicareWagesAndTipsCorrect(this, "Helper"),
                new RcwMedicareWagesAndTipsOriginal(this, "Helper"),
                new RcwMiddleNameEmployeeCorrect(this, "Helper"),
                new RcwMiddleNameEmployeeOriginal(this, "Helper"),
                new RcwNonQualifiedDeferredCompensationPlanCodeYCorrect(this, "Helper"),
                new RcwNonQualifiedDeferredCompensationPlanCodeYOriginal(this, "Helper"),
                new RcwNonQualifiedPlanNotSection457Correct(this, "Helper"),
                new RcwNonQualifiedPlanNotSection457Original(this, "Helper"),
                new RcwNonQualifiedPlanSection457Correct(this, "Helper"),
                new RcwNonQualifiedPlanSection457Original(this, "Helper"),
                new RcwNontaxableCombatPayCodeQCorrect(this, "Helper"),
                new RcwNontaxableCombatPayCodeQOriginal(this, "Helper"),
                new RcwPermittedBenefitsUnderAQSEHRACodeFFCorrect(this, "Helper"),
                new RcwPermittedBenefitsUnderAQSEHRACodeFFOriginal(this, "Helper"),
                new RcwRetirementPlanIndicatorCorrect(this, "Helper"),
                new RcwRetirementPlanIndicatorOriginal(this, "Helper"),
                new RcwSocialSecurityNumberCorrect(this, "Helper"),
                new RcwSocialSecurityNumberOriginal(this, "Helper"),
                new RcwSocialSecurityTaxWithheldCorrect(this, "Helper"),
                new RcwSocialSecurityTaxWithheldOriginal(this, "Helper"),
                new RcwSocialSecurityTipsCorrect(this, "Helper"),
                new RcwSocialSecurityTipsOriginal(this, "Helper"),
                new RcwSocialSecurityWagesCorrect(this, "Helper"),
                new RcwSocialSecurityWagesOriginal(this, "Helper"),
                new RcwStateAbbreviation(this, "Helper"),
                new RcwStatutoryEmployeeIndicatorCorrect(this, "Helper"),
                new RcwStatutoryEmployeeIndicatorOriginal(this, "Helper"),
                new RcwThirdPartySickPayndicatorCorrect(this, "Helper"),
                new RcwThirdPartySickPayndicatorOriginal(this, "Helper"),
                new RcwTotalDeferredCompensationContributionsCorrect(this, "Helper"),
                new RcwTotalDeferredCompensationContributionsOriginal(this, "Helper"),
                new RcwWagesTipsAndOtherCompensationCorrect(this, "Helper"),
                new RcwWagesTipsAndOtherCompensationOriginal(this, "Helper"),
                new RcwZipCode (this, "Helper"),
                new RcwZipCodeExtension(this, "Helper"),
            };
        }
    }
}
