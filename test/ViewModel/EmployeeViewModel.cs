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

namespace test.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {

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

        public ICommand VerifyEmployeeCommand { get; set; }
        public ICommand VerifyEmployeeOptionalCommand { get; set; }
        public ICommand VerifyEmployeeStateCommand { get; set; }

        public EmployeeViewModel() 
        {
            VerifyEmployeeCommand = new RelayCommand(VerifyEmployeeCommandHandler);
            VerifyEmployeeOptionalCommand = new RelayCommand(VerifyEmployeeOptionalCommandHandler);
            VerifyEmployeeStateCommand = new RelayCommand(VerifyEmployeeStateCommandHandler);
            _employee = new W2cEmployee(new W2cDocument());

        }

        private void VerifyEmployeeCommandHandler()
        {
            try
            {
                _employee.Verify();
            }
            catch(Exception ex) 
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
            catch(Exception ex) 
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
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
