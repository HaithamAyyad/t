using EFW2C.Fields;
using EFW2C.Manager;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class TestClass
    {
        public void test()
        {
            var fileName1 = @"C:\1\1.txt";
            var fileName2 = @"C:\1\2.txt";
            var fileName3 = @"C:\1\W2CSampleFile.txt";
            var fileName4 = @"C:\1\4.txt";

            try
            {
                var manager = new RecordManager();
                manager.SetSubmitter(true);
                manager.SetTIB(true);

                var rcaRecord = CreateRcaRecord(manager);
                rcaRecord.Write();
                manager.SetRcaRecord(rcaRecord);

                var rceRecord = CreateRceRecord(manager);
                rceRecord.Write();
                rceRecord.Verify();

                var rcoRecord = CreateRcoRecord(manager);
                rcoRecord.Write();
                
                var rcsRecord = CreateRcsRecord(manager);
                rcsRecord.Write();

                var rcwRecord = CreateRcwRecord(manager);
                rcwRecord.SetRcoRecord(rcoRecord);
                rcwRecord.SetRcsRecord(rcsRecord);
                rcwRecord.Write();
                rceRecord.AddRcwRecord(rcwRecord);
                
                var rcvRecord = CreateRcvRecord(manager);
                rcvRecord.Write();
                rceRecord.SetRcvRecord(rcvRecord);

                manager.AddRceRecord(rceRecord);

                /*
                
                //rce 2
                rceRecord = CreateRceRecord(manager);
                rceRecord.Write();
                rceRecord.Verify();

                rcoRecord = CreateRcoRecord2(manager);
                rcoRecord.Write();

                rcsRecord = CreateRcsRecord(manager);
                rcsRecord.Write();

                rcwRecord = CreateRcwRecord(manager);
                rcwRecord.SetParent(rceRecord);
                rcwRecord.SetRcoRecord(rcoRecord);
                rcwRecord.SetRcsRecord(rcsRecord);
                rcwRecord.Write();
                rceRecord.AddRcwRecord(rcwRecord);

                rcvRecord = CreateRcvRecord(manager);
                rcvRecord.Write();
                rceRecord.SetRcvRecord(rcvRecord);

                manager.AddRceRecord(rceRecord);
                
                */
                manager.Close();
                manager.Verify();


                var manager2 = manager.Clone();
                manager2.Close();

                manager.WriteToFile(fileName1);
                manager2.WriteToFile(fileName2);

                if (!AreFilesIdentical_testfunction(fileName1, fileName2))
                    throw new Exception($"for testing {fileName1} is not equal to {fileName2}");

                RecordManager manager3 = RecordManager.CreateManager(fileName3);

                manager3.WriteToFile(fileName4);

                if (!AreFilesIdentical_testfunction(fileName4, fileName3))
                    throw new Exception($"for testing {fileName1} is not equal to {fileName3}");

      
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

        static bool AreFilesIdentical_testfunction(string filePath1, string filePath2)
        {
            byte[] fileBytes1 = File.ReadAllBytes(filePath1);
            byte[] fileBytes2 = File.ReadAllBytes(filePath2);


            if (fileBytes1.Length != fileBytes2.Length)
            {
                return false;
            }

            for (int i = 0; i < fileBytes1.Length; i++)
            {
                if (fileBytes1[i] != fileBytes2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private RcsRecord CreateRcsRecord(RecordManager manager)
        {
            var rcsRecord = new RcsRecord(manager);

            return rcsRecord;
        }

        private RcwRecord CreateRcwRecord(RecordManager manager)
        {
            var rcwRecord = new RcwRecord(manager);

            rcwRecord.AddField(new RcwZipCode(rcwRecord, "11118"));
            rcwRecord.AddField(new RcwZipCodeExtension(rcwRecord, "1117"));
            rcwRecord.AddField(new RcwStateAbbreviation(rcwRecord, "AL"));
            rcwRecord.AddField(new RcwLocationAddress(rcwRecord, "ggg"));
            rcwRecord.AddField(new RcwDeliveryAddress(rcwRecord, "Alask box 444 0"));
            rcwRecord.AddField(new RcwCity(rcwRecord, "City1"));
            //rcwRecord.AddField(new RcwForeignStateProvince(rcwRecord, "KKK"));
            rcwRecord.AddField(new RcwForeignPostalCode(rcwRecord, "BOX 300"));
            //rcwRecord.AddField(new RcwCountryCode(rcwRecord, "UK"));
            rcwRecord.AddField(new RcwSocialSecurityNumberCorrect(rcwRecord, "123456789"));
            rcwRecord.AddField(new RcwSocialSecurityNumberOriginal(rcwRecord, "122456789"));
            rcwRecord.AddField(new RcwSocialSecurityTaxWithheldCorrect(rcwRecord, "5656"));
            rcwRecord.AddField(new RcwSocialSecurityTaxWithheldOriginal(rcwRecord, "5656"));
            rcwRecord.AddField(new RcwEmployeeFirstNameOriginal(rcwRecord, "John"));
            rcwRecord.AddField(new RcwEmployeeFirstNameCorrect(rcwRecord, "John"));
            rcwRecord.AddField(new RcwEmployeeLastNameCorrect(rcwRecord, "Smith"));
            rcwRecord.AddField(new RcwEmployeeLastNameOriginal(rcwRecord, "Smith"));
            return rcwRecord;
        }

        private RcoRecord CreateRcoRecord(RecordManager manager)
        {
            var rcoRecord = new RcoRecord(manager);

            rcoRecord.AddField(new RcoAllocatedTipsCorrect(rcoRecord, "10"));
            rcoRecord.AddField(new RcoAllocatedTipsOriginal(rcoRecord, "10"));

            return rcoRecord;
        }

        private RcoRecord CreateRcoRecord2(RecordManager manager)
        {
            var rcoRecord = new RcoRecord(manager);

            rcoRecord.AddField(new RcoAllocatedTipsCorrect(rcoRecord, "3"));
            rcoRecord.AddField(new RcoAllocatedTipsOriginal(rcoRecord, "1"));

            return rcoRecord;
        }

        private RcvRecord CreateRcvRecord(RecordManager manager)
        {
            var rcvRecord = new RcvRecord(manager);
            rcvRecord.AddField(new RcvSupplementalData(rcvRecord, " this is data from user"));
            return rcvRecord;
        }

        private RceRecord CreateRceRecord(RecordManager manager)
        {
            var rceRecord = new RceRecord(manager);

            rceRecord.AddField(new RceTaxYear(rceRecord, "1960"));
            rceRecord.AddField(new RceKindOfEmployer(rceRecord, "S"));
            rceRecord.AddField(new RceAgentIndicator(rceRecord, "1"));
            rceRecord.AddField(new RceEinAgentFederal(rceRecord, "123456789"));
            rceRecord.AddField(new RceEinAgent(rceRecord, "123456789"));
            rceRecord.AddField(new RceEmployerName(rceRecord, "employer1"));

            return rceRecord;
        }

        private RcaRecord CreateRcaRecord(RecordManager manager)
        {
            var rcaRecord = new RcaRecord(manager);
            rcaRecord.AddField(new RcaEinSubmitter(rcaRecord, "773456789"));
            rcaRecord.AddField(new RcaSoftwareCode(rcaRecord, "99"));
            rcaRecord.AddField(new RcaUserIdentification(rcaRecord, "12345678"));
            rcaRecord.AddField(new RcaSoftwareVendorCode(rcaRecord, "4444"));
            rcaRecord.AddField(new RcaSubmitterName(rcaRecord, "Adam"));
            rcaRecord.AddField(new RcaContactName(rcaRecord, "john"));
            rcaRecord.AddField(new RcaZipCode(rcaRecord, "11118"));
            rcaRecord.AddField(new RcaZipCodeExtension(rcaRecord, "1117"));
            rcaRecord.AddField(new RcaStateAbbreviation(rcaRecord, "AL"));
            rcaRecord.AddField(new RcaLocationAddress(rcaRecord, "dfd"));
            rcaRecord.AddField(new RcaDeliveryAddress(rcaRecord, "Alask box 444 0"));
            rcaRecord.AddField(new RcaCity(rcaRecord, "City1"));
            //rcaRecord.AddField(new RcaForeignStateProvince(rcaRecord, "KKK"));
            rcaRecord.AddField(new RcaForeignPostalCode(rcaRecord, "BOX 300"));
            //rcaRecord.AddField(new RcaCountryCode(rcaRecord, "UK"));
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
