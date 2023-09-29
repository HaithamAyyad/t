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
using test.View;

namespace test.ViewModel
{
    public class EmployerViewModel : INotifyPropertyChanged
    {

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

        public ICommand VerifyCommand { get; set; }
        public ICommand CreateEmployeeCommand { get; set; }


        public EmployerViewModel() 
        {
            VerifyCommand = new RelayCommand(VerifyCommandHandler);
            CreateEmployeeCommand = new RelayCommand(CreateEmployeeCommandHandler);

            _employer = new W2cEmployer(new W2cDocument());

        }

        private void VerifyCommandHandler()
        {
            try
            {
                _employer.Verify();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateEmployeeCommandHandler()
        {
            var employeeWindow = new EmployeeWindow();
            employeeWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
