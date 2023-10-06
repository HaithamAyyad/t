using EFW2C.RecordEFW2C.W2cDocument;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using test.Command;
using test.Interface;
using test.View;

namespace test.ViewModel
{
    public class DocumentViewModel : IViewModel, INotifyPropertyChanged
    {
        W2cDocument _document;

        int _windowIndex;
        string _initialDirectory = @"c:\W2C_test\";

        private W2cSubmitter _submitter;
        public W2cSubmitter Submitter
        {
            get { return _submitter; }
            set
            {
                if (_submitter != value)
                {
                    _submitter = value;
                    OnPropertyChanged();
                }
            }
        }


        private W2cEmployeeState _employeeState;
        public W2cEmployeeState EmployeeState
        {
            get { return _employeeState; }
            set
            {
                if (_employeeState != value)
                {
                    _employeeState = value;
                    OnPropertyChanged();
                }
            }
        }

        public W2cEmployeeStateTotal _employeeStateTotal;
        public W2cEmployeeStateTotal EmployeeStateTotal
        {
            get { return _employeeStateTotal; }
            set
            {
                if (_employeeStateTotal != value)
                {
                    _employeeStateTotal = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _showSubmitter;
        public bool ShowSubmitter
        {
            get { return _showSubmitter; }
            set
            {
                if (_showSubmitter != value)
                {
                    _showSubmitter = value;
                    OnPropertyChanged();
                }
            }
        }


        private bool _showEmployer;
        public bool ShowEmployer
        {
            get { return _showEmployer; }
            set
            {
                if (_showEmployer != value)
                {
                    _showEmployer = value;
                    OnPropertyChanged();
                }
            }
        }


        private bool _showEmployeeCollection;
        public bool ShowEmployeeCollection
        {
            get { return _showEmployeeCollection; }
            set
            {
                if (_showEmployeeCollection != value)
                {
                    _showEmployeeCollection = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand VerifySubmitterCommand { get; set; }
        public ICommand VerifyEmployerCommand { get; set; }
        public ICommand VerifyEmployeeCommand { get; set; }
        public ICommand VerifyEmployeeOptionalCommand { get; set; }
        public ICommand VerifyEmployeeStateCommand { get; set; }

        public ICommand NextCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand PreviousCommand { get; set; }

        public W2cDocument Document { get { return _document; } }
        public DocumentViewModel()
        {
            VerifySubmitterCommand = new RelayCommand(VerifySubmitterCommandHandler);
            VerifyEmployerCommand = new RelayCommand(VerifyEmployerCommandHandler);
            VerifyEmployeeCommand = new RelayCommand(VerifyEmployeeCommandHandler);
            VerifyEmployeeOptionalCommand = new RelayCommand(VerifyEmployeeOptionalCommandHandler);
            VerifyEmployeeStateCommand = new RelayCommand(VerifyEmployeeStateCommandHandler);
            NextCommand = new RelayCommand(NextCommandHandler);
            CreateCommand = new RelayCommand(CreateCommandHandler);
            PreviousCommand = new RelayCommand(PreviousCommandHandler);

            _document = new W2cDocument();

            _submitter = new W2cSubmitter(_document);

            _employeeState = new W2cEmployeeState(_document);
            _employeeStateTotal = new W2cEmployeeStateTotal(_document);

            test_FillData();

            ShowHideWindows();
        }

        private void test_FillData()
        {
            _submitter.EinSubmitter = "12-3456789";
            _submitter.SoftwareCode = "99";
            _submitter.UserIdentification = "12345678";
            _submitter.SoftwareVendorCode = "4444";
            _submitter.SubmitterName = "Adam";
            _submitter.ContactName = "john";
            _submitter.ZipCode = "11118";
            _submitter.ZipCodeExtension = "1117";
            _submitter.StateAbbreviation = "AL";
            _submitter.LocationAddress = "dfd";
            _submitter.DeliveryAddress = "Alask box 444 0";
            _submitter.City = "City1";
            _submitter.ForeignPostalCode = "BOX 300";
            _submitter.ContactPhone = "9090000000";
            _submitter.ContactPhoneExtension = "108";
            _submitter.ContactEMailInternet = "e@t.com";
            _submitter.ContactFax = "123456456";
            _submitter.PreparerCode = "A";
            _submitter.ResubIndicator = "0";

            var employee = new W2cEmployee(_document);

            employee.ZipCode = "11118";
            employee.ZipCodeExtension = "1117";
            employee.StateAbbreviation = "AL";
            employee.LocationAddress = "ggg";
            employee.DeliveryAddress = "Alask box 444 0";
            employee.City = "City1";
            employee.ForeignPostalCode = "BOX 300";
            employee.SocialSecurityNumberCorrect = "888-43-7777";
            employee.SocialSecurityNumberOriginal = "123456789";
            employee.SocialSecurityTaxWithheldCorrect = "56.56";
            employee.SocialSecurityTaxWithheldOriginal = "56";
            employee.EmployeeFirstNameOriginal = "John";
            employee.EmployeeFirstNameCorrect = "John";
            employee.EmployeeLastNameCorrect = "Smith";
            employee.EmployeeLastNameOriginal = "Smith";

            var employeeOptional = new W2cEmployeeOptional(_document);

            employeeOptional.AllocatedTipsCorrect = "40.9";
            employeeOptional.AllocatedTipsOriginal = "80.";

            employee.SetEmployeeOptional(employeeOptional);

            _employeeStateTotal.SupplementalData = " this is data from user";

            var employer1 = new W2cEmployer(_document);

            employer1.TaxYear = "1960";
            employer1.KindOfEmployer = "S";
            employer1.AgentIndicator = "1";
            employer1.EinAgentFederal = "123456789";
            employer1.EinAgent = "123456789";
            employer1.EmployerName = "employer0";

            var employer2 = new W2cEmployer(_document);

            employer2.TaxYear = "2023";
            employer2.KindOfEmployer = "K";
            employer2.AgentIndicator = "1";
            employer2.EinAgentFederal = "999999999";
            employer2.EinAgent = "000000000";
            employer2.EmployerName = "employer1";

            employer1.AddEmployee(employee);

            _document.AddEmployer(employer1);
            _document.AddEmployer(employer2);
        }

        internal void HandleDoubleClickEmployerListBox(object selectedItem)
        {
            if (selectedItem as W2cEmployer != null)
            {
                _windowIndex = 1;
                ShowHideWindows();
            }
        }

        internal void HandleDoubleClickEmployeeListBox(object selectedItem)
        {
            if (selectedItem as W2cEmployee != null)
            {
                _windowIndex = 2;
                ShowHideWindows();
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

        private void VerifySubmitterCommandHandler()
        {
            try
            {
                _submitter.Verify();
                MessageBox.Show("Verified Successfully", "Subbmitter");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerifyEmployerCommandHandler()
        {
            try
            {
                _document.SelectedEmployer?.Verify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerifyEmployeeCommandHandler()
        {
            try
            {
                _document.SelectedEmployer?.SelectedEmployee?.Verify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerifyEmployeeOptionalCommandHandler()
        {
            try
            {
                _document.SelectedEmployer?.SelectedEmployee?.EmployeeOptional?.Verify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerifyEmployeeStateCommandHandler()
        {
            try
            {
                _employeeState.Verify();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void CreateCommandHandler()
        {
            try
            {
                if (!GetSaveFileName(out var fileName))
                    return;

                _document.SetSubmitter(_submitter);

                /*_employer.AddEmployee(_employee);

                _employeeOptional.Prepare();
                _employee.SetEmployeeOptional(_employeeOptional);

                _employeeState.Prepare();
                _employee.SetEmployeeState(_employeeState);

                _employeeStateTotal.Prepare();
                _employer.SetEmployeeStateTotal(_employeeStateTotal);
                _employer.Prepare();
                _document.AddEmployer(_employer);

                */

                _document.Verify();
                _document.SaveDocument(fileName);
                MessageBox.Show($"{fileName} : Document created correctly");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool GetSaveFileName(out string fileName)
        {
            fileName = string.Empty;

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save WC2 Document";
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            saveFileDialog.InitialDirectory = _initialDirectory;

            if (saveFileDialog.ShowDialog() == false)
                return false;

            fileName = saveFileDialog.FileName;

            _initialDirectory = saveFileDialog.InitialDirectory;

            return true;
        }

        private void NextCommandHandler()
        {
            MoveToNextWindow();
        }

        private void PreviousCommandHandler()
        {
            MoveToPreviousWindow();
        }

        private void MoveToPreviousWindow()
        {
            _windowIndex--;
            ShowHideWindows();
        }

        private void MoveToNextWindow()
        {
            _windowIndex++;
            ShowHideWindows();
        }

        private void ShowHideWindows()
        {
            _windowIndex = Math.Max(0, _windowIndex);
            _windowIndex = Math.Min(_windowIndex, 2);

            ShowSubmitter = _windowIndex == 0; 
            ShowEmployer = _windowIndex == 1; 
            ShowEmployeeCollection = _windowIndex == 2; 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
