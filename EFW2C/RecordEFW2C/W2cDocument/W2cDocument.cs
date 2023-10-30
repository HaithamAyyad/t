using EFW2C.Manager;
using EFW2C.RecordEFW2C.Helpper;
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

namespace EFW2C.W2cDocument
{
    public class W2cDocument : INotifyPropertyChanged
    {
        private W2cSubmitter _submitter;
        private RecordManager _manager;

        private ObservableCollection<W2cEmployer> _employerList;
        public IEnumerable<W2cEmployer> EmployerList => _employerList;

        public W2cSubmitter Submitter { get { return _submitter; } }

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

        public void MoveToNextEmployer()
        {
            var index = _employerList.IndexOf(SelectedEmployer) + 1;
            if (index < _employerList.Count)
                SelectedEmployer = _employerList[index];
        }

        public void MoveToPreviousEmployer()
        {
            var index = _employerList.IndexOf(SelectedEmployer) - 1;
            if (index >= 0)
                SelectedEmployer = _employerList[index];
        }

        public bool CanMoveToNextEmployer()
        {
            return _employerList.IndexOf(SelectedEmployer) < _employerList.Count - 1;
        }

        public bool CanMoveToPreviousEmployer()
        {
            return _employerList.IndexOf(SelectedEmployer) > 0;
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

        public void Prepar()
        {
            _submitter?.Prepare();

            foreach (var employer in _employerList)
                employer.Prepare();
        }

        public void Reset()
        {
            SetSubmitter(null);
            _employerList.Clear();
            _manager.Reset();
        }

        public static List<string> GetUsaStateNames()
        {
            return DictionaryHelper.UsaStateName.Keys.ToList();
        }

        public static string GetUsaAbbRreviationsStateNames(string stateName)
        {
            if (DictionaryHelper.UsaStateName.ContainsKey(stateName))
                return DictionaryHelper.UsaStateName[stateName];

            return string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
