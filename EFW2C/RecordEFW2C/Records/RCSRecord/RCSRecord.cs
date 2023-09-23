using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using System;
using System.Collections.Generic;

namespace EFW2C.Records
{
    public class RcsRecord : RecordBase
    {
        public RcsRecord(RecordManager recordManager)
            : base(recordManager, RecordNameEnum.Rcs.ToString())
        {
        }

        public RcsRecord(RecordManager recordManager, char[] buffer)
            : base(recordManager, RecordNameEnum.Rcs.ToString(), buffer)
        {
        }

        public override RecordBase Clone(RecordManager manager)
        {
            var rcsRecord = new RcsRecord(manager);

            CloneData(rcsRecord, manager);

            return rcsRecord;
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

        protected override List<FieldBase> CreateVerifyFieldsList()
        {
            return new List<FieldBase>
            {
                new RcsCity(this, "dummy"),
                new RcsCountryCode(this, "dummy"),
                new RcsDateFirstEmployedCorrect(this, "dummy"),
                new RcsDateFirstEmployedOriginal(this, "dummy"),
                new RcsDateOfSeparationCorrect(this, "dummy"),
                new RcsDateOfSeparationOriginal(this, "dummy"),
                new RcsDeliveryAddress(this, "dummy"),
                new RcsEmployeeFirstNameCorrect(this, "dummy"),
                new RcsEmployeeFirstNameOriginal(this, "dummy"),
                new RcsEmployeeLastNameCorrect(this, "dummy"),
                new RcsEmployeeLastNameOriginal(this, "dummy"),
                new RcsEmployeeMiddleNameCorrect(this, "dummy"),
                new RcsEmployeeMiddleNameOriginal(this, "dummy"),
                new RcsForeignPostalCode(this, "dummy"),
                new RcsForeignStateProvince(this, "dummy"),
                new RcsIdentifierField(this),
                new RcsLocalTaxableWagesCorrect(this, "dummy"),
                new RcsLocalTaxableWagesOriginal(this, "dummy"),
                new RcsLocationAddress(this, "dummy"),
                new RcsNumberOfWeeksWorkedCorrect(this, "dummy"),
                new RcsNumberOfWeeksWorkedOriginal(this, "dummy"),
                new RcsOptionalCode(this, "dummy"),
                new RcsOtherStateData(this, "dummy"),
                new RcsReportingPeriodCorrect(this, "dummy"),
                new RcsReportingPeriodOriginal(this, "dummy"),
                new RcsSocialSecurityNumberCorrect(this, "dummy"),
                new RcsSocialSecurityNumberOriginal(this, "dummy"),
                new RcsStateAbbreviation(this, "dummy"),
                new RcsStateCode(this, "dummy"),
                new RcsStateCodeIncomeTax(this, "dummy"),
                new RcsStateControlNumberCorrect(this, "dummy"),
                new RcsStateControlNumberOriginal(this, "dummy"),
                new RcsStateEmployerAccountNumberCorrect(this, "dummy"),
                new RcsStateEmployerAccountNumberOriginal(this, "dummy"),
                new RcsStateIncomeTaxWithheldCorrect(this, "dummy"),
                new RcsStateIncomeTaxWithheldOriginal(this, "dummy"),
                new RcsStateQuarterlyUnemploymentInsuranceTotalWagesCorrect(this, "dummy"),
                new RcsStateQuarterlyUnemploymentInsuranceTotalWagesOriginal(this, "dummy"),
                new RcsStateTaxableWagesCorrect(this, "dummy"),
                new RcsStateTaxableWagesOriginal(this, "dummy"),
                new RcsSupplementalData1(this, "dummy"),
                new RcsSupplementalData2(this, "dummy"),
                new RcsTaxingEntityCodeCorrect(this, "dummy"),
                new RcsTaxingEntityCodeOriginal(this, "dummy"),
                new RcsTaxTypeCodeCorrect(this, "dummy"),
                new RcsTaxTypeCodeOriginal(this, "dummy"),
                new RcsZipCode (this, "dummy"),
                new RcsZipCodeExtension(this, "dummy"),
            };
        }
    }
}
