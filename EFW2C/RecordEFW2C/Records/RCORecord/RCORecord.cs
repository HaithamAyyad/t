using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Languages;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RcoRecord : RecordBase
    {
        private RcwRecord _parent;
        public RcwRecord Parent { get { return _parent; } }

        public RcoRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rco.ToString())
        {
            Prepare();
        }

        public RcoRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rco.ToString(), buffer)
        {
            Prepare();
        }

        public void SetParent(RcwRecord parent)
        {
            _parent = parent;
        }
        public override RecordBase Clone(RecordManager manager)
        {
            var rcoRecord = new RcoRecord(manager);

            CloneData(rcoRecord);

            return rcoRecord;
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
                new Tuple<int, int>(3, 9),
                new Tuple<int, int>(188, 22),
                new Tuple<int, int>(276, 748)
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
                new RcoRecordIdentifier(this),
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
