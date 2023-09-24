using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcoRecord : RecordBase
    {
        public RcoRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rco.ToString())
        {
            AddField(new RcoIdentifierField(this));
        }

        public RcoRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rco.ToString(), buffer)
        {
            AddField(new RcoIdentifierField(this));
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcoRecord = new RcoRecord(manager);

            CloneData(rcoRecord, manager);

            return rcoRecord;
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

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcoAggregateDeferralsCodeHHCorrect(this, "Helper"),
                new RcoAggregateDeferralsCodeHHOriginal(this, "Helper"),
                new RcoAllocatedTipsCorrect(this, "Helper"),
                new RcoAllocatedTipsOriginal(this, "Helper"),
                new RcoDesignatedRothContributionsCodeEECorrect(this, "Helper"),
                new RcoDesignatedRothContributionsCodeEEOriginal(this, "Helper"),
                new RcoIdentifierField(this),
                new RcoIncomeFromQualifiedEquityCodeGGCorrect(this, "Helper"),
                new RcoIncomeFromQualifiedEquityCodeGGOriginal(this, "Helper"),
                new RcoIncomeUnderANonQualifiedDeferredCompensationPlanCodeZCorrect(this, "Helper"),
                new RcoIncomeUnderANonQualifiedDeferredCompensationPlanCodeZOriginal(this, "Helper"),
                new RcoMedicalSavingsAccountCodeRCorrect(this, "Helper"),
                new RcoMedicalSavingsAccountCodeROriginal(this, "Helper"),
                new RcoQualifiedAdoptionExpensesCodeTCorrect(this, "Helper"),
                new RcoQualifiedAdoptionExpensesCodeTOriginal(this, "Helper"),
                new RcoSimpleRetirementAccountCodeSCorrect(this, "Helper"),
                new RcoSimpleRetirementAccountCodeSOriginal(this, "Helper"),
                new RcoUncollectedEmployeeTaxOnTipsCodesABCorrect(this, "Helper"),
                new RcoUncollectedEmployeeTaxOnTipsCodesABOriginal(this, "Helper"),
                new RcoUncollectedMedicareTaxCodeNCorrect(this, "Helper"),
                new RcoUncollectedMedicareTaxCodeNOriginal(this, "Helper"),
                new RcoUncollectedSocialSecurityOrRRTATaxCodeMCorrect(this, "Helper"),
                new RcoUncollectedSocialSecurityOrRRTATaxCodeMOriginal(this, "Helper"),
            };
        }
    }
}
