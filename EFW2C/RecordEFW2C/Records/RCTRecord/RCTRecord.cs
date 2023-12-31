﻿using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Languages;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RctRecord : RecordBase
    {
        private RceRecord _parent;

        public RceRecord Parent { get { return _parent; } }

        public RctRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rct.ToString())
        {
            Prepare();
        }

        public RctRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rct.ToString(), buffer)
        {
            Prepare();
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rctRecord = new RctRecord(manager);

            CloneData(rctRecord);

            return rctRecord;
        }

        public void SetParent(RceRecord parent)
        {
            _parent = parent;
        }

        public override bool Verify()
        {
            if (_parent == null)
                throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeAddedTo, "Employee"));

            return base.Verify();
        }

        protected override List<Tuple<int, int>> CreateBlankList()
        {
            return new List<Tuple<int, int>>
            {
                new Tuple<int, int>(220, 30),
                new Tuple<int, int>(460, 30),
                new Tuple<int, int>(610, 30),
                new Tuple<int, int>(850, 174)
            };
        }
        
        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RctRecordIdentifier(this),
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
                new RctTotalNonQualifiedDeferredCompensationPlanCodeYCorrect(this),
                new RctTotalNonQualifiedDeferredCompensationPlanCodeYOriginal(this),
                new RctTotalNonQualifiedPlanNotSection457Correct(this),
                new RctTotalNonQualifiedPlanNotSection457Original(this),
                new RctTotalNonQualifiedPlanSection457Correct(this),
                new RctTotalNonQualifiedPlanSection457Original(this),
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
