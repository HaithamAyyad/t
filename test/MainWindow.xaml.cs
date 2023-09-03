﻿using EFW2C.Common.Enum;
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

                manager.AddRecord(CreateRcaRecord(manager));
                manager.AddRecord(CreateRceRecord(manager));
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

        private RecordBase CreateRcfRecord(RecordManager manager)
        {
            var rcfRecord = new RCFRecord(manager);
            rcfRecord.AddField(new RcfRecordIdentifier(rcfRecord));
            rcfRecord.AddField(new RcfNumberOfRCWRecord(rcfRecord));
            return rcfRecord;
        }

        private RecordBase CreateRcvRecord(RecordManager manager)
        {
            var rcvRecord = new RCVRecord(manager);
            rcvRecord.AddField(new RcvRecordIdentifier(rcvRecord));
            rcvRecord.AddField(new RcvSupplementalData(rcvRecord," this is data from user"));

            return rcvRecord;
        }

        private RecordBase CreateRceRecord(RecordManager manager)
        {
            var rceRecord = new RCERecord(manager);
            rceRecord.AddField(new RceRecordIdentifier(rceRecord));
            rceRecord.AddField(new RceTaxYear(rceRecord, "1960"));

            return rceRecord;
        }

        private RecordBase CreateRcaRecord(RecordManager manager)
        {
            var rcaRecord = new RCARecord(manager);
            rcaRecord.SetForeignAddress(true);
            rcaRecord.AddField(new RcaIdentifierField(rcaRecord));
            rcaRecord.AddField(new RcaSubmitterEinField(rcaRecord, "773456789"));
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

            return rcaRecord;
        }
    }
}
