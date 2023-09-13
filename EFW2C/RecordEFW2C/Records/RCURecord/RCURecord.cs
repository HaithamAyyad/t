﻿using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcuRecord : RecordBase
    {
        public RcuRecord(RecordManager recordManager)
            : base(recordManager)
        {
            RecordName = RecordNameEnum.Rcu.ToString();
            SumRecordClassName = RecordNameEnum.Rco.ToString();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (250, 30),
                (370, 654)
            };
        }

        protected override List<FieldBase> CreateChildClassFields()
        {
            return new List<FieldBase>
            {
                new RcuIdentifierField(this),
                new RcuNumberOfRCORecord(this),
                new RcuTotalAggregateDeferralsCodeHHCorrect(this),
                new RcuTotalAggregateDeferralsCodeHHOriginal(this),
                new RcuTotalAllocatedTipsCorrect(this),
                new RcuTotalAllocatedTipsOriginal(this),
                new RcuTotalDesignatedRothContributionsCodeEECorrect(this),
                new RcuTotalDesignatedRothContributionsCodeEEOriginal(this),
                new RcuTotalIncomeFromQualifiedEquityCodeGGCorrect(this),
                new RcuTotalIncomeFromQualifiedEquityCodeGGOriginal(this),
                new RcuTotalIncomeUnderANonqualifiedDeferredCompensationPlanCodeZCorrect(this),
                new RcuTotalIncomeUnderANonqualifiedDeferredCompensationPlanCodeZOriginal(this),
                new RcuTotalMedicalSavingsAccountCodeRCorrect(this),
                new RcuTotalMedicalSavingsAccountCodeROriginal(this),
                new RcuTotalQualifiedAdoptionExpensesCodeTCorrect(this),
                new RcuTotalQualifiedAdoptionExpensesCodeTOriginal(this),
                new RcuTotalSimpleRetirementAccountCodeSCorrect(this),
                new RcuTotalSimpleRetirementAccountCodeSOriginal(this),
                new RcuTotalUncollectedEmployeeTaxOnTipsCodesABCorrect(this),
                new RcuTotalUncollectedEmployeeTaxOnTipsCodesABOriginal(this),
                new RcuTotalUncollectedMedicareTaxCodeNCorrect(this),
                new RcuTotalUncollectedMedicareTaxCodeNOriginal(this),
                new RcuTotalUncollectedSocialSecurityOrRRTATaxCodeMCorrect(this),
                new RcuTotalUncollectedSocialSecurityOrRRTATaxCodeMOriginal(this),
            };
        }
    }
}