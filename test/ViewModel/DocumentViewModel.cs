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
using test.Testing;
using test.View;

namespace test.ViewModel
{
    public class DocumentViewModel : IViewModel, INotifyPropertyChanged
    {
        W2cDocument _document;

        int _windowIndex;
        string _initialDirectory = @"c:\W2C_test\";

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
        public ICommand CreateRandomEmployeeCommand { get; set; }
        public ICommand CreateRandomEmployerCommand { get; set; }
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
            CreateRandomEmployeeCommand = new RelayCommand(CreateRandomEmployeeCommandHandler);
            CreateRandomEmployerCommand = new RelayCommand(CreateRandomEmployerCommandHandler);
            VerifyEmployeeOptionalCommand = new RelayCommand(VerifyEmployeeOptionalCommandHandler);
            VerifyEmployeeStateCommand = new RelayCommand(VerifyEmployeeStateCommandHandler);
            NextCommand = new RelayCommand(NextCommandHandler);
            CreateCommand = new RelayCommand(CreateCommandHandler);
            PreviousCommand = new RelayCommand(PreviousCommandHandler);

            _document = new W2cDocument();

            _employeeState = new W2cEmployeeState(_document);
            _employeeStateTotal = new W2cEmployeeStateTotal(_document);

            //DocumentDataTest.FillData(_document);
            
            DocumentDataTest.FillData_staically(_document);

            ShowHideWindows();
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
                _document.Submitter.Prepare();
                _document.Submitter.Verify();
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
                _document.SelectedEmployer?.Prepare();
                _document.SelectedEmployer?.Verify();
                MessageBox.Show("Verified Successfully", "Employer");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateRandomEmployeeCommandHandler()
        {
           
            try
            {
                var employee = DocumentDataTest.CreateEmployeeRandomly(_document);
                var employeeOptional = DocumentDataTest.CreateEmployeeOptionalRandomly(_document);
                //var employeeState = DocumentDataTest.CreateEmployeeState(_document);

                employee.SetEmployeeOptional(employeeOptional);
                //employee.SetEmployeeState(employeeState);

                _document.SelectedEmployer?.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateRandomEmployerCommandHandler()
        {
            try
            {
                var employee = DocumentDataTest.CreateEmployeeRandomly(_document);
                var employeeOptional = DocumentDataTest.CreateEmployeeOptionalRandomly(_document);

                employee.SetEmployeeOptional(employeeOptional);

                var employer = DocumentDataTest.CreateEmployerRandomly(_document);

                employer.AddEmployee(employee);

                _document.AddEmployer(employer);
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
                _document.SelectedEmployer?.SelectedEmployee?.Prepare();
                _document.SelectedEmployer?.SelectedEmployee?.Verify();
                MessageBox.Show("Verified Successfully", "Employee");
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
                _document.SelectedEmployer?.SelectedEmployee?.EmployeeOptionalRecord?.Prepare();
                _document.SelectedEmployer?.SelectedEmployee?.EmployeeOptionalRecord?.Verify();
                MessageBox.Show("Verified Successfully", "Employee Optional");
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
                MessageBox.Show("Verified Successfully", "Employer State");
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

                _document.Prepar();
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
