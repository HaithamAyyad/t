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
    public class DocumentViewModel : IDocumentViewModel, INotifyPropertyChanged
    {

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

        public ICommand VerifyCommand { get; set; }
        public ICommand CreateEmployerCommand { get; set; }

        public DocumentViewModel() 
        {
            VerifyCommand = new RelayCommand(VerifyCommandHandler);
            CreateEmployerCommand = new RelayCommand(CreateEmployerCommandHandler);

            _submitter = new W2cSubmitter(new W2cDocument());
        }

        private void CreateEmployerCommandHandler()
        {
            var employerWindow = new EmployerWindow();
            employerWindow.ShowDialog();
        }

        private void VerifyCommandHandler()
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
