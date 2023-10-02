using EFW2C.RecordEFW2C.W2cDocument;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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


        private W2cEmployer _employer;
        public W2cEmployer Employer
        {
            get { return _employer; }
            set
            {
                if (_employer != value)
                {
                    _employer = value;
                    OnPropertyChanged();
                }
            }
        }


        private W2cEmployee _employee;
        public W2cEmployee Employee
        {
            get { return _employee; }
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged();
                }
            }
        }


        private W2cEmployeeOptional _employeeOptional;
        public W2cEmployeeOptional EmployeeOptional
        {
            get { return _employeeOptional; }
            set
            {
                if (_employeeOptional != value)
                {
                    _employeeOptional = value;
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


        private W2cEmployer _employerList;
        public W2cEmployer EmployerList
        {
            get { return _employerList; }
            set 
            {
                if (_employerList != value)
                {
                    _employerList = value;
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
        public ICommand PreviousCommand { get; set; }

        public W2cDocument Document{ get { return _document; }}
        public DocumentViewModel() 
        {
            VerifySubmitterCommand = new RelayCommand(VerifySubmitterCommandHandler);
            VerifyEmployerCommand = new RelayCommand(VerifyEmployerCommandHandler);
            VerifyEmployeeCommand = new RelayCommand(VerifyEmployeeCommandHandler);
            VerifyEmployeeOptionalCommand = new RelayCommand(VerifyEmployeeOptionalCommandHandler);
            VerifyEmployeeStateCommand = new RelayCommand(VerifyEmployeeStateCommandHandler);
            NextCommand = new RelayCommand(NextCommandHandler);
            PreviousCommand = new RelayCommand(PreviousCommandHandler);

            _document = new W2cDocument();

            _submitter = new W2cSubmitter(_document);
            _employer = new W2cEmployer(_document);
            _employee = new W2cEmployee(_document);
            _employeeOptional = new W2cEmployeeOptional(_document);
            _employeeState = new W2cEmployeeState(_document);
            _employeeStateTotal = new W2cEmployeeStateTotal(_document);

            test();

            ShowHideWindows();
        }

        private void test()
        {

            _submitter.EinSubmitter = "773456789";
            _submitter.SoftwareCode= "99";
            _submitter.UserIdentification= "12345678";
            _submitter.SoftwareVendorCode= "4444";
            _submitter.SubmitterName= "Adam";
            _submitter.ContactName= "john";
            _submitter.ZipCode= "11118";
            _submitter.ZipCodeExtension= "1117";
            _submitter.StateAbbreviation= "AL";
            _submitter.LocationAddress= "dfd";
            _submitter.DeliveryAddress= "Alask box 444 0";
            _submitter.City = "City1";
            //_submitter.ForeignStateProvince="KKK";
            _submitter.ForeignPostalCode= "BOX 300";
            //_submitter.CountryCode="UK";
            _submitter.ContactPhone= "9090000000";
            _submitter.ContactPhoneExtension= "108";
            _submitter.ContactEMailInternet= "e@t.com";
            _submitter.ContactFax= "123456456";
            _submitter.PreparerCode= "A";
            _submitter.ResubIndicator= "0";
            //_submitter.ResubWageFile= "hjhfj";

            _submitter.Prepare();

            _document.SetSubmitter(_submitter);

            _employee.ZipCode = "11118";
            _employee.ZipCodeExtension = "1117";
            _employee.StateAbbreviation = "AL";
            _employee.LocationAddress = "ggg";
            _employee.DeliveryAddress = "Alask box 444 0";
            _employee.City = "City1";
            //_employee.ForeignStateProvince = "KKK";
            _employee.ForeignPostalCode = "BOX 300";
            //_employee.CountryCode= ="UK";
            _employee.SocialSecurityNumberCorrect = "123456789";
            _employee.SocialSecurityNumberOriginal = "122456789";
            _employee.SocialSecurityTaxWithheldCorrect = "5656";
            _employee.SocialSecurityTaxWithheldOriginal = "5656";
            _employee.EmployeeFirstNameOriginal = "John";
            _employee.EmployeeFirstNameCorrect = "John";
            _employee.EmployeeLastNameCorrect = "Smith";
            _employee.EmployeeLastNameOriginal = "Smith";

            _employee.Prepare();

            _employer.AddEmployee(_employee);

            _employeeOptional.AllocatedTipsCorrect = "10";
            _employeeOptional.AllocatedTipsOriginal = "10";
            _employeeOptional.Prepare();

            _employee.SetEmployeeOptional(_employeeOptional);
            _employeeState.Prepare();
            _employee.SetEmployeeState(_employeeState);

            _employeeStateTotal.SupplementalData = " this is data from user";
            _employeeStateTotal.Prepare();
            _employer.SetEmployeeStateTotal(_employeeStateTotal);

            _employer.TaxYear = "1960";
            _employer.KindOfEmployer = "S";
            _employer.AgentIndicator = "1";
            _employer.EinAgentFederal = "123456789";
            _employer.EinAgent = "123456789";
            _employer.EmployerName = "employer1";

            _employer.Prepare();
            _document.AddEmployer(_employer);

            _document.SaveDocument(@"c:\1\4.txt");

            AreFilesIdentical_testfunction(@"c:\1\1.txt", @"c:\1\4.txt");
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
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerifyEmployerCommandHandler()
        {
            try
            {
                _employer.Verify();
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
                _employee.Verify();
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
                _employeeOptional.Verify();
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
