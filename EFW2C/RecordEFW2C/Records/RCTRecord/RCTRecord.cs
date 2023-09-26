﻿using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RctRecord : RecordBase
    {
        private RceRecord _rceRecord;
        public RceRecord RceRecord { get;}

        public RctRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rct.ToString())
        {
            AddField(new RctIdentifierField(this));
        }

        public RctRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rct.ToString(), buffer)
        {
            AddField(new RctIdentifierField(this));
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rctRecord = new RctRecord(manager);

            CloneData(rctRecord);

            return rctRecord;
        }

        public void SetRceRecord(RceRecord rceRecord)
        {
            if (_isLocked)
                throw new Exception($"Employee Total record is locked");

            _rceRecord = rceRecord;
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (220, 30),
                (460, 30),
                (610, 30),
                (850, 174)
            };
        }
        
        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RctIdentifierField(this),
                new RctNumberOfRCWRecords(this),
                new RctTotalCostOfEmployerSponsoredHealthCoverageCodeDDCorrect(this),
                new RctTotalCostOfEmployerSponsoredHealthCoverageCodeDDOriginal(this),
                new RctTotalDeferredCompensationCodeDCorrect(this),
                new RctTotalDeferredCompensationCodeDOriginal(this),
                new RctTotalDeferredCompensationCodeECorrect(this),
                new RctTotalDeferredCompensationCodeEOriginal(this),
                new RctTotalDeferredCompensationCodeFCorrect(this),
                new RctTotalDeferredCompensationCodeFOriginal(this),
                new RctTotalDeferredCompensationCodeGCorrect(this),
                new RctTotalDeferredCompensationCodeGOriginal(this),
                new RctTotalDeferredCompensationCodeHCorrect(this),
                new RctTotalDeferredCompensationCodeHOriginal(this),
                new RctTotalDependentCareBenefitsCorrect(this),
                new RctTotalDependentCareBenefitsOriginal(this),
                new RctTotalDesignatedRothCodeAACorrect(this),
                new RctTotalDesignatedRothCodeAAOriginal(this),
                new RctTotalDesignatedRothCodeBBCorrect(this),
                new RctTotalDesignatedRothCodeBBOriginal(this),
                new RctTotalEmployerContributionsToSHealthSavingsAccountCodeWCorrect(this),
                new RctTotalEmployerContributionsToSHealthSavingsAccountCodeWOriginal(this),
                new RctTotalEmployerCostOfPremiumsCodeCCorrect(this),
                new RctTotalEmployerCostOfPremiumsCodeCOriginal(this),
                new RctTotalFederalIncomeTaxWithheldCorrect(this),
                new RctTotalFederalIncomeTaxWithheldOriginal(this),
                new RctTotalIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVCorrect(this),
                new RctTotalIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal(this),
                new RctTotalMedicareTaxWithheldCorrect(this),
                new RctTotalMedicareTaxWithheldOriginal(this),
                new RctTotalMedicareWagesAndTipsCorrect(this),
                new RctTotalMedicareWagesAndTipsOriginal(this),
                new RctTotalNonqualifiedDeferredCompensationPlanCodeYCorrect(this),
                new RctTotalNonqualifiedDeferredCompensationPlanCodeYOriginal(this),
                new RctTotalNonqualifiedPlanNotSection457Correct(this),
                new RctTotalNonqualifiedPlanNotSection457Original(this),
                new RctTotalNonqualifiedPlanSection457Correct(this),
                new RctTotalNonqualifiedPlanSection457Original(this),
                new RctTotalNontaxableCombatPayCodeQCorrect(this),
                new RctTotalNontaxableCombatPayCodeQOriginal(this),
                new RctTotalPermittedBenefitsUnderAQSEHRACodeFFCorrect(this),
                new RctTotalPermittedBenefitsUnderAQSEHRACodeFFOriginal(this),
                new RctTotalSocialSecurityTaxWithheldCorrect(this),
                new RctTotalSocialSecurityTaxWithheldOriginal(this),
                new RctTotalSocialSecurityTipsCorrect(this),
                new RctTotalSocialSecurityTipsOriginal(this),
                new RctTotalSocialSecurityWagesCorrect(this),
                new RctTotalSocialSecurityWagesOriginal(this),
                new RctTotalTotalDeferredCompensationContributionsCorrect(this),
                new RctTotalTotalDeferredCompensationContributionsOriginal(this),
                new RctTotalWagesTipsAndOtherCompensationCorrect(this),
                new RctTotalWagesTipsAndOtherCompensationOriginal(this),
            };
        }
    }
}
