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
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rcw.ToString();
        }

        public RcwRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, buffer)
        {
            RecordName = RecordNameEnum.Rcw.ToString();
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

        protected override List<FieldBase> CreateVerifyFieldsList()
        {
            return new List<FieldBase>
            {
                new RcwCity(this, "dummy"),
                new RcwCostOfEmployerSponsoredHealthCoverageCodeDDCorrect(this, "dummy"),
                new RcwCostOfEmployerSponsoredHealthCoverageCodeDDOriginal(this, "dummy"),
                new RcwCountryCode(this, "dummy"),
                new RcwDeferredCompensationCodeDCorrect(this, "dummy"),
                new RcwDeferredCompensationCodeDOriginal(this, "dummy"),
                new RcwDeferredCompensationCodeECorrect(this, "dummy"),
                new RcwDeferredCompensationCodeEOriginal(this, "dummy"),
                new RcwDeferredCompensationCodeFCorrect(this, "dummy"),
                new RcwDeferredCompensationCodeFOriginal(this, "dummy"),
                new RcwDeferredCompensationCodeGCorrect(this, "dummy"),
                new RcwDeferredCompensationCodeGOriginal(this, "dummy"),
                new RcwDeferredCompensationCodeHCorrect(this, "dummy"),
                new RcwDeferredCompensationCodeHOriginal(this, "dummy"),
                new RcwDeliveryAddress(this, "dummy"),
                new RcwDependentCareBenefitsCorrect(this, "dummy"),
                new RcwDependentCareBenefitsOriginal(this, "dummy"),
                new RcwDesignatedRothCodeAACorrect(this, "dummy"),
                new RcwDesignatedRothCodeAAOriginal(this, "dummy"),
                new RcwDesignatedRothCodeBBCorrect(this, "dummy"),
                new RcwDesignatedRothCodeBBOriginal(this, "dummy"),
                new RcwEmployeeFirstNameCorrect(this, "dummy"),
                new RcwEmployeeFirstNameOriginal(this, "dummy"),
                new RcwEmployeeLastNameCorrect(this, "dummy"),
                new RcwEmployeeLastNameOriginal(this, "dummy"),
                new RcwEmployerContributionsToSHealthSavingsAccountCodeWCorrect(this, "dummy"),
                new RcwEmployerContributionsToSHealthSavingsAccountCodeWOriginal(this, "dummy"),
                new RcwEmployerCostOfPremiumsCodeCCorrect(this, "dummy"),
                new RcwEmployerCostOfPremiumsCodeCCOriginal(this, "dummy"),
                new RcwFederalIncomeTaxWithheldCorrect(this, "dummy"),
                new RcwFederalIncomeTaxWithheldOriginal(this, "dummy"),
                new RcwForeignPostalCode(this, "dummy"),
                new RcwForeignStateProvince(this, "dummy"),
                new RcwIdentifierField(this),
                new RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect(this, "dummy"),
                new RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal(this, "dummy"),
                new RcwLocationAddress(this, "dummy"),
                new RcwMedicareTaxWithheldCorrect(this, "dummy"),
                new RcwMedicareTaxWithheldOriginal(this, "dummy"),
                new RcwMedicareWagesAndTipsCorrect(this, "dummy"),
                new RcwMedicareWagesAndTipsOriginal(this, "dummy"),
                new RcwMiddleNameEmployeeCorrect(this, "dummy"),
                new RcwMiddleNameEmployeeOriginal(this, "dummy"),
                new RcwNonqualifiedDeferredCompensationPlanCodeYCorrect(this, "dummy"),
                new RcwNonqualifiedDeferredCompensationPlanCodeYOriginal(this, "dummy"),
                new RcwNonqualifiedPlanNotSection457Correct(this, "dummy"),
                new RcwNonqualifiedPlanNotSection457Original(this, "dummy"),
                new RcwNonqualifiedPlanSection457Correct(this, "dummy"),
                new RcwNonqualifiedPlanSection457Original(this, "dummy"),
                new RcwNontaxableCombatPayCodeQCorrect(this, "dummy"),
                new RcwNontaxableCombatPayCodeQOriginal(this, "dummy"),
                new RcwPermittedBenefitsUnderAQSEHRACodeFFCorrect(this, "dummy"),
                new RcwPermittedBenefitsUnderAQSEHRACodeFFOriginal(this, "dummy"),
                new RcwRetirementPlanIndicatorCorrect(this, "dummy"),
                new RcwRetirementPlanIndicatorOriginal(this, "dummy"),
                new RcwSocialSecurityNumberCorrect(this, "dummy"),
                new RcwSocialSecurityNumberOriginal(this, "dummy"),
                new RcwSocialSecurityTaxWithheldCorrect(this, "dummy"),
                new RcwSocialSecurityTaxWithheldOriginal(this, "dummy"),
                new RcwSocialSecurityTipsCorrect(this, "dummy"),
                new RcwSocialSecurityTipsOriginal(this, "dummy"),
                new RcwSocialSecurityWagesCorrect(this, "dummy"),
                new RcwSocialSecurityWagesOriginal(this, "dummy"),
                new RcwStateAbbreviation(this, "dummy"),
                new RcwStatutoryEmployeeIndicatorCorrect(this, "dummy"),
                new RcwStatutoryEmployeeIndicatorOriginal(this, "dummy"),
                new RcwThirdPartySickPayndicatorCorrect(this, "dummy"),
                new RcwThirdPartySickPayndicatorOriginal(this, "dummy"),
                new RcwTotalDeferredCompensationContributionsCorrect(this, "dummy"),
                new RcwTotalDeferredCompensationContributionsOriginal(this, "dummy"),
                new RcwWagesTipsAndOtherCompensationCorrect(this, "dummy"),
                new RcwWagesTipsAndOtherCompensationOriginal(this, "dummy"),
                new RcwZIPCode (this, "dummy"),
                new RcwZIPCodeExtension(this, "dummy"),
            };
        }
    }
}
