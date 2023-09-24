using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcwRecord : RecordBase
    {
        public RcwRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcw.ToString())
        {
            AddField(new RcwIdentifierField(this));
        }

        public RcwRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcw.ToString(), buffer)
        {
            AddField(new RcwIdentifierField(this));
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcwRecord = new RcwRecord(manager);

            CloneData(rcwRecord, manager);

            return rcwRecord;
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
                new RcwIdentifierField(this),
                new RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect(this, "Helper"),
                new RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal(this, "Helper"),
                new RcwLocationAddress(this, "Helper"),
                new RcwMedicareTaxWithheldCorrect(this, "Helper"),
                new RcwMedicareTaxWithheldOriginal(this, "Helper"),
                new RcwMedicareWagesAndTipsCorrect(this, "Helper"),
                new RcwMedicareWagesAndTipsOriginal(this, "Helper"),
                new RcwMiddleNameEmployeeCorrect(this, "Helper"),
                new RcwMiddleNameEmployeeOriginal(this, "Helper"),
                new RcwNonqualifiedDeferredCompensationPlanCodeYCorrect(this, "Helper"),
                new RcwNonqualifiedDeferredCompensationPlanCodeYOriginal(this, "Helper"),
                new RcwNonqualifiedPlanNotSection457Correct(this, "Helper"),
                new RcwNonqualifiedPlanNotSection457Original(this, "Helper"),
                new RcwNonqualifiedPlanSection457Correct(this, "Helper"),
                new RcwNonqualifiedPlanSection457Original(this, "Helper"),
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
