using EFW2C.Common.Enum;
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

                var rca = new RCARecord();


                rca.AddField(new RcaIdentifierField(rca, "RCA"));

                rca.AddField(new RcaSubmitterEinField(rca, "773456789"));
                rca.AddField(new RcaSoftwareCode(rca, "98"));
                rca.AddField(new RcaUserIdentification(rca, "12345678"));
                rca.AddField(new RcaSoftwareVendorCode(rca, "4444"));

                rca.AddField(new RcaSubmitterName(rca, "Haitham"));
                rca.AddField(new RcaContactName(rca, "john"));
                rca.AddField(new RcaZIPCode(rca, "11118"));
                rca.AddField(new RcaZIPCodeExtension(rca, "1117"));
                rca.AddField(new RcaStateAbbreviation(rca, "01"));

                manager.AddRecord(rca);

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
    }
}
