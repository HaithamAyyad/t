using EFW2C.RecordEFW2C.W2cDocument;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using test.Command;
using test.View;
using test.WindowManager;

namespace test.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _showOptionalRecord;
        public bool ShowOptionalRecord
        {
            get { return _showOptionalRecord; }
            set 
            {
                if (_showOptionalRecord != value)
                {
                    _showOptionalRecord = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _numberOfRandomRecords;

        public string NumberOfRandomRecords
        {
            get { return _numberOfRandomRecords; }
            set 
            {
                if (_numberOfRandomRecords != value)
                {
                    _numberOfRandomRecords = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateDocumentCommand { get; set; }

        public MainViewModel() 
        {
            CreateDocumentCommand = new RelayCommand(CreateDocumentCommandHandler);
            _numberOfRandomRecords = "1";
        }

        private void CreateDocumentCommandHandler()
        {
            int.TryParse(NumberOfRandomRecords, out var nRr);
            var documentViewModel = new DocumentViewModel(_showOptionalRecord, nRr);
            
            var documentWindow = WindowsManager.CreateWindow(documentViewModel);
            documentWindow.ShowDialog();

            //documentViewModel.Document.SaveDocument()
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
