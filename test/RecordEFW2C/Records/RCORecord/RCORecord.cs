﻿using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RCORecord : RecordBase
    {
        public RCORecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.RCO.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (3, 9),
                (188, 22),
                (276, 748)
            };
        }

        protected override List<FieldBase> CreateChildClassFields()
        {
            return new List<FieldBase>
            {
                new RcoAggregateDeferralsCodeHHCorrect(this, "dummy"),
                new RcoAggregateDeferralsCodeHHOriginal(this, "dummy"),
                new RcoAllocatedTipsCorrect(this, "dummy"),
                new RcoAllocatedTipsOriginal(this, "dummy"),
                new RcoDesignatedRothContributionsCodeEECorrect(this, "dummy"),
                new RcoDesignatedRothContributionsCodeEEOriginal(this, "dummy"),
                new RcoIdentifierField(this),
                new RcoIncomeFromQualifiedEquityCodeGGCorrect(this, "dummy"),
                new RcoIncomeFromQualifiedEquityCodeGGOriginal(this, "dummy"),
                new RcoMedicalSavingsAccountCodeRCorrect(this, "dummy"),
                new RcoMedicalSavingsAccountCodeROriginal(this, "dummy"),
                new RcoMedicalSavingsAccountCodeROriginal(this, "dummy"),
                new RcoNonQualifiedDeferredCodeZCorrect(this, "dummy"),
                new RcoNonQualifiedDeferredCodeZOriginal(this, "dummy"),
                new RcoQualifiedAdoptionExpensesCodeTCorrect(this, "dummy"),
                new RcoQualifiedAdoptionExpensesCodeTOriginal(this, "dummy"),
                new RcoSimpleRetirementAccountCodeSCorrect(this, "dummy"),
                new RcoSimpleRetirementAccountCodeSOriginal(this, "dummy"),
                new RcoUncollectedEmployeeTaxonTipsCodesABCorrect(this, "dummy"),
                new RcoUncollectedEmployeeTaxonTipsCodesABOriginal(this, "dummy"),
                new RcoUncollectedMedicareTaxCodeNCorrect(this, "dummy"),
                new RcoUncollectedMedicareTaxCodeNOriginal(this, "dummy"),
                new RcoUncollectedSocialSecurityOrRRTATaxCodeMCorrect(this, "dummy"),
                new RcoUncollectedSocialSecurityOrRRTATaxCodeMOriginal(this, "dummy"),
            };
        }
    }
}
