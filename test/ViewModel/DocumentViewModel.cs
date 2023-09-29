using EFW2C.RecordEFW2C.W2cDocument;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
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

        private W2cState _employeeState;
        public W2cState EmployeeState
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

        private string _employerList;
        public string EmployerList
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
            _employeeState = new W2cState(_document);

            ShowHideWindow();
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
            _windowIndex++;
            ShowHideWindow();
        }

        private void PreviousCommandHandler()
        {
            _windowIndex--;
            ShowHideWindow();
        }

        private void ShowHideWindow()
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
