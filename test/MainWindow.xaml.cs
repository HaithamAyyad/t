﻿using EFW2C.Common.Enums;
using EFW2C.Fields;
using EFW2C.Manager;
using EFW2C.Records;
using System;
using System.Windows;


namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                var manager = new RecordManager();
                manager.SetSubmitter(true);

                manager.AddRecord(CreateRcaRecord(manager));
                manager.AddRecord(CreateRceRecord(manager));
                manager.AddRecord(CreateRcwRecord(manager));
                manager.AddRecord(CreateRcoRecord(manager));
                manager.AddRecord(CreateRcsRecord(manager));
                manager.AddRecord(CreateRctRecord(manager));
                manager.AddRecord(CreateRcuRecord(manager));
                manager.AddRecord(CreateRcvRecord(manager));
                manager.AddRecord(CreateRcfRecord(manager));

                manager.write();

                if (!manager.Verify())
                    MessageBox.Show("Error");
                else
                    MessageBox.Show("Sucess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private RecordBase CreateRctRecord(RecordManager manager)
        {
            var rctRecord = new RctRecord(manager);

            return rctRecord;
        }

        private RecordBase CreateRcsRecord(RecordManager manager)
        {
            var rcsRecord = new RcsRecord(manager);

            return rcsRecord;
        }

        private RecordBase CreateRcuRecord(RecordManager manager)
        {
            var rcuRecord = new RcuRecord(manager);

            rcuRecord.AddField(new RcuIdentifierField(rcuRecord));
            rcuRecord.AddField(new RcuNumberOfRCORecord(rcuRecord));
            rcuRecord.AddField(new RcuTotalAllocatedTipsOriginal(rcuRecord));
            rcuRecord.AddField(new RcuTotalAllocatedTipsCorrect(rcuRecord));

            return rcuRecord;



        }

        private RecordBase CreateRcwRecord(RecordManager manager)
        {
            var rcwRecord = new RcwRecord(manager);

            rcwRecord.AddField(new RcwIdentifierField(rcwRecord));
            rcwRecord.AddField(new RcwZIPCode(rcwRecord, "11118"));
            rcwRecord.AddField(new RcwZIPCodeExtension(rcwRecord, "1117"));
            rcwRecord.AddField(new RcwStateAbbreviation(rcwRecord, "AL"));
            rcwRecord.AddField(new RcwLocationAddress(rcwRecord, "ggg"));
            rcwRecord.AddField(new RcwDeliveryAddress(rcwRecord, "Alask box 444 0"));
            rcwRecord.AddField(new RcwCity(rcwRecord, "City1"));
            rcwRecord.AddField(new RcwForeignStateProvince(rcwRecord, "KKK"));
            rcwRecord.AddField(new RcwForeignPostalCode(rcwRecord, "BOX 300"));
            rcwRecord.AddField(new RcwCountryCode(rcwRecord, "UK"));
            rcwRecord.AddField(new RcwSocialSecurityNumberCorrect(rcwRecord, "123456789"));
            rcwRecord.AddField(new RcwSocialSecurityNumberOriginal(rcwRecord, "122456789"));
            rcwRecord.AddField(new RcwSocialSecurityTaxWithheldCorrect(rcwRecord, "5656"));
            rcwRecord.AddField(new RcwSocialSecurityTaxWithheldOriginal(rcwRecord, "5656"));
            return rcwRecord;
        }

        private RecordBase CreateRcoRecord(RecordManager manager)
        {
            var rcoRecord = new RcoRecord(manager);

            rcoRecord.AddField(new RcoIdentifierField(rcoRecord));
            rcoRecord.AddField(new RcoAllocatedTipsCorrect(rcoRecord, "10"));
            rcoRecord.AddField(new RcoAllocatedTipsOriginal(rcoRecord, "10"));
           
            return rcoRecord;
        }
        private RecordBase CreateRcoRecord2(RecordManager manager)
        {
            var rcoRecord = new RcoRecord(manager);

            rcoRecord.AddField(new RcoIdentifierField(rcoRecord));
            rcoRecord.AddField(new RcoAllocatedTipsCorrect(rcoRecord, "3"));
            rcoRecord.AddField(new RcoAllocatedTipsOriginal(rcoRecord, "1"));
           
            return rcoRecord;
        }

        private RecordBase CreateRcfRecord(RecordManager manager)
        {
            var rcfRecord = new RcfRecord(manager);
            rcfRecord.AddField(new RcfIdentifierField(rcfRecord));
            rcfRecord.AddField(new RcfNumberOfRCWRecord(rcfRecord));
            return rcfRecord;
        }

        private RecordBase CreateRcvRecord(RecordManager manager)
        {
            var rcvRecord = new RcvRecord(manager);
            rcvRecord.AddField(new RcvIdentifierField(rcvRecord)); ;
            rcvRecord.AddField(new RcvSupplementalData(rcvRecord," this is data from user"));
            return rcvRecord;
        }

        private RecordBase CreateRceRecord(RecordManager manager)
        {
            var rceRecord = new RceRecord(manager);

            rceRecord.AddField(new RceIdentifierField(rceRecord));
            rceRecord.AddField(new RceTaxYear(rceRecord, "1960"));
            rceRecord.AddField(new RceKindOfEmployer(rceRecord, "S"));
            rceRecord.AddField(new RceAgentIndicator(rceRecord, "1"));
            rceRecord.AddField(new RceEinAgentFederal(rceRecord, "123456789"));
            rceRecord.AddField(new RceEinAgent(rceRecord, "123456789"));
            rceRecord.AddField(new RceEmployerName(rceRecord, "employer1"));

            return rceRecord;
        }

        private RecordBase CreateRcaRecord(RecordManager manager)
        {
            var rcaRecord = new RcaRecord(manager);
            rcaRecord.SetForeignAddress(true);
            rcaRecord.AddField(new RcaIdentifierField(rcaRecord));
            rcaRecord.AddField(new RcaEinSubmitterField(rcaRecord, "773456789"));
            rcaRecord.AddField(new RcaSoftwareCode(rcaRecord, "98"));
            rcaRecord.AddField(new RcaUserIdentification(rcaRecord, "12345678"));
            rcaRecord.AddField(new RcaSoftwareVendorCode(rcaRecord, "4444"));
            rcaRecord.AddField(new RcaSubmitterName(rcaRecord, "Adam"));
            rcaRecord.AddField(new RcaContactName(rcaRecord, "john"));
            rcaRecord.AddField(new RcaZIPCode(rcaRecord, "11118"));
            rcaRecord.AddField(new RcaZIPCodeExtension(rcaRecord, "1117"));
            rcaRecord.AddField(new RcaStateAbbreviation(rcaRecord, "AL"));
            rcaRecord.AddField(new RcaLocationAddress(rcaRecord, ""));
            rcaRecord.AddField(new RcaDeliveryAddress(rcaRecord, "Alask box 444 0"));
            rcaRecord.AddField(new RcaCity(rcaRecord, "City1"));
            rcaRecord.AddField(new RcaForeignStateProvince(rcaRecord, "KKK"));
            rcaRecord.AddField(new RcaForeignPostalCode(rcaRecord, "BOX 300"));
            rcaRecord.AddField(new RcaCountryCode(rcaRecord, "UK"));
            rcaRecord.AddField(new RcaContactPhone(rcaRecord, "9090000000"));
            rcaRecord.AddField(new RcaContactPhoneExtension(rcaRecord, "108"));
            rcaRecord.AddField(new RcaContactEMailInternet(rcaRecord, "e@t.com"));
            rcaRecord.AddField(new RcaContactFax(rcaRecord, "123456456"));
            rcaRecord.AddField(new RcaPreparerCode(rcaRecord, "A"));
            rcaRecord.AddField(new RcaResubIndicator(rcaRecord, "1"));
            rcaRecord.AddField(new RcaResubWageFile(rcaRecord, "hjhfj"));

            return rcaRecord;
        }
    }
}
