using EFW2C.Manager;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cDocument : INotifyPropertyChanged
    {
        private W2cSubmitter _submitter;
        private RecordManager _manager;

        private ObservableCollection<W2cEmployer> _employerList;
        public IEnumerable<W2cEmployer> EmployerList => _employerList;

        private W2cEmployer _selectedEmployer;
        public W2cEmployer SelectedEmployer
        {
            get { return _selectedEmployer; }
            set
            {
                if (_selectedEmployer != value)
                {
                    _selectedEmployer = value;
                    OnPropertyChanged();
                }
            }
        }

        internal RecordManager Manager { get { return _manager; } }

        public W2cDocument()
        {
            _manager = new RecordManager();
            _employerList = new ObservableCollection<W2cEmployer>();
        }

        public void SetSubmitter(W2cSubmitter submitter)
        {
            _submitter = submitter;
            _manager.SetRcaRecord(_submitter.InternalRecord);
        }

        public void AddEmployer(W2cEmployer employer)
        {
            if (employer != null && !_employerList.Contains(employer))
            {
                _manager.AddRceRecord(employer.InternalRecord);
                _employerList.Add(employer);
                SelectedEmployer = employer;
            }
        }

        public void AddEmployers(List<W2cEmployer> employerList)
        {
            if (employerList != null)
            {
                foreach (var employer in employerList)
                    AddEmployer(employer);
            }
        }

        public bool Verify()
        {
            if (!_submitter.Verify())
                return false;

            foreach (var employer in _employerList)
            {
                if (!employer.Verify())
                    return false;
            }

            return true;
        }


        public void SaveDocument(string fileName)
        {
            Prepar();
            _manager.Close();
            _manager.WriteToFile(fileName);
        }

        private void Prepar()
        {
            _submitter?.Prepare();

            foreach (var employer in _employerList)
                employer.Verify();
        }

        public void Reset()
        {
            SetSubmitter(null);
            _employerList.Clear();
            _manager.Reset();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
