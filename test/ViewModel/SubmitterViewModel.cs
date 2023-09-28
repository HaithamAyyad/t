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
    public class SubmitterViewModel : INotifyPropertyChanged
    {


        private W2cSubmitter _submitter;

        public W2cSubmitter Submitter
        {
            get { return _submitter; }
            set 
            {
                _submitter = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerifyCommand { get; set; }

        public SubmitterViewModel() 
        {
            VerifyCommand = new RelayCommand(VerifyCommandHandler);
            _submitter = new W2cSubmitter(new W2cDocument());
            _submitter.Ein = "h";
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
