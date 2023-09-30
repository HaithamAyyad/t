using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    internal class RcsRecord : RecordBase
    {
        private RcwRecord _parent;
        public RcwRecord Pranet { get { return _parent; } }

        public RcsRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcs.ToString())
        {
            AddField(new RcsRecordIdentifier(this));
        }

        public RcsRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcs.ToString(), buffer)
        {
            AddField(new RcsRecordIdentifier(this));
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcsRecord = new RcsRecord(manager);

            CloneData(rcsRecord);

            return rcsRecord;
        }

        public void SetParent(RcwRecord parent)
        {
            _parent = parent;
        }

        protected override List<(int, int)> CreateBlankList()
        {
            return new List<(int, int)>
            {
                (210, 5),
                (269, 6),
                (333, 10),
                (383, 12),
                (799, 225)
            };
        }

        protected override List<FieldBase> CreateHelperFieldsList()
        {
            return new List<FieldBase>
            {
                new RcsCity(this, "Helper"),
                new RcsCountryCode(this, "Helper"),
                new RcsDateFirstEmployedCorrect(this, "Helper"),
                new RcsDateFirstEmployedOriginal(this, "Helper"),
                new RcsDateOfSeparationCorrect(this, "Helper"),
                new RcsDateOfSeparationOriginal(this, "Helper"),
                new RcsDeliveryAddress(this, "Helper"),
                new RcsEmployeeFirstNameCorrect(this, "Helper"),
                new RcsEmployeeFirstNameOriginal(this, "Helper"),
                new RcsEmployeeLastNameCorrect(this, "Helper"),
                new RcsEmployeeLastNameOriginal(this, "Helper"),
                new RcsEmployeeMiddleNameCorrect(this, "Helper"),
                new RcsEmployeeMiddleNameOriginal(this, "Helper"),
                new RcsForeignPostalCode(this, "Helper"),
                new RcsForeignStateProvince(this, "Helper"),
                new RcsRecordIdentifier(this),
                new RcsLocalTaxableWagesCorrect(this, "Helper"),
                new RcsLocalTaxableWagesOriginal(this, "Helper"),
                new RcsLocationAddress(this, "Helper"),
                new RcsNumberOfWeeksWorkedCorrect(this, "Helper"),
                new RcsNumberOfWeeksWorkedOriginal(this, "Helper"),
                new RcsOptionalCode(this, "Helper"),
                new RcsOtherStateData(this, "Helper"),
                new RcsReportingPeriodCorrect(this, "Helper"),
                new RcsReportingPeriodOriginal(this, "Helper"),
                new RcsSocialSecurityNumberCorrect(this, "Helper"),
                new RcsSocialSecurityNumberOriginal(this, "Helper"),
                new RcsStateAbbreviation(this, "Helper"),
                new RcsStateCode(this, "Helper"),
                new RcsStateCodeIncomeTax(this, "Helper"),
                new RcsStateControlNumberCorrect(this, "Helper"),
                new RcsStateControlNumberOriginal(this, "Helper"),
                new RcsStateEmployerAccountNumberCorrect(this, "Helper"),
                new RcsStateEmployerAccountNumberOriginal(this, "Helper"),
                new RcsStateIncomeTaxWithheldCorrect(this, "Helper"),
                new RcsStateIncomeTaxWithheldOriginal(this, "Helper"),
                new RcsStateQuarterlyUnemploymentInsuranceTotalWagesCorrect(this, "Helper"),
                new RcsStateQuarterlyUnemploymentInsuranceTotalWagesOriginal(this, "Helper"),
                new RcsStateTaxableWagesCorrect(this, "Helper"),
                new RcsStateTaxableWagesOriginal(this, "Helper"),
                new RcsSupplementalData1(this, "Helper"),
                new RcsSupplementalData2(this, "Helper"),
                new RcsTaxingEntityCodeCorrect(this, "Helper"),
                new RcsTaxingEntityCodeOriginal(this, "Helper"),
                new RcsTaxTypeCodeCorrect(this, "Helper"),
                new RcsTaxTypeCodeOriginal(this, "Helper"),
                new RcsZipCode (this, "Helper"),
                new RcsZipCodeExtension(this, "Helper"),
            };
        }
    }
}
