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
        private string _documentName;

        public string DocumentName
        {
            get { return _documentName; }
            set 
            {
                if (_documentName != value)
                {
                    _documentName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateDocumentCommand { get; set; }

        public MainViewModel() 
        {
            CreateDocumentCommand = new RelayCommand(CreateDocumentCommandHandler);
        }

        private void CreateDocumentCommandHandler()
        {
            var documentViewModel = new DocumentViewModel();
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
