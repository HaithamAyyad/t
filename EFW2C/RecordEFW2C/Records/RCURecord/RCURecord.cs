using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RcuRecord : RecordBase
    {
        private RceRecord _parent;

        public RceRecord Parent { get { return _parent; } }

        public RcuRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcu.ToString())
        {
            AddField(new RcuRecordIdentifier(this));
        }

        public RcuRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcu.ToString(), buffer)
        {
            AddField(new RcuRecordIdentifier(this));
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcuRecord = new RcuRecord(manager);

            CloneData(rcuRecord);

            return rcuRecord;
        }

        public void SetParent(RceRecord parent)
        {
            _parent = parent;
        }

        public override bool Verify()
        {
            if (_parent == null)
                throw new Exception($"Total-Optional: must be added to Employer");

            return !base.Verify();
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (250, 30),
                (370, 654)
            };
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcuRecordIdentifier(this),
                new RcuNumberOfRCORecord (this),
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
