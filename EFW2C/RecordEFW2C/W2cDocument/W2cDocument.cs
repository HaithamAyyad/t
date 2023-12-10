using EFW2C.Common.Enums;
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
            _submitter?.Verify();

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
            return DictionaryHelper.UsaStateNameDictionary.Keys.ToList();
        }

        public static string GetUsaAbbreviationsState(string stateName)
        {
            if (!string.IsNullOrEmpty(stateName))
            {
                if (DictionaryHelper.UsaStateNameDictionary.ContainsKey(stateName))
                    return DictionaryHelper.UsaStateNameDictionary[stateName];
            }

            return string.Empty;
        }

        public static string GetUsaStateName(string stateAbbreviation)
        {
            if (!string.IsNullOrEmpty(stateAbbreviation))
            {
                var stateName = DictionaryHelper.UsaStateNameDictionary.FirstOrDefault(x => x.Value == stateAbbreviation).Key;

                if (stateName != null)
                    return stateName;
            }

            return string.Empty;
        }

        public static List<string> GetEmploymentCodeNames()
        {
            return DictionaryHelper.EmploymentCodeNameDictionary.Keys.ToList();
        }

        public static List<string> GetCountryCodeNames()
        {
            return Enum.GetNames(typeof(CountryCode)).ToList();
        }

        public static string GetEmploymentCodeAbbreviation(string employmentCodeName)
        {
            if (!string.IsNullOrEmpty(employmentCodeName))
            {
                if (DictionaryHelper.EmploymentCodeNameDictionary.ContainsKey(employmentCodeName))
                    return DictionaryHelper.EmploymentCodeNameDictionary[employmentCodeName];
            }

            return string.Empty;
        }

        public static string GetEmploymentCodeName(string employmentCodeAbbreviation)
        {
            if (!string.IsNullOrEmpty(employmentCodeAbbreviation))
            {
                var employmentCode = DictionaryHelper.EmploymentCodeNameDictionary.FirstOrDefault(x => x.Value == employmentCodeAbbreviation).Key;

                if (employmentCode != null)
                    return employmentCode;
            }

            return string.Empty;
        }


        public static List<string> GetKindOfEmployerNames()
        {
            return DictionaryHelper.KindOfEmployerNameDictionary.Keys.ToList();
        }

        public static string GetKindOfEmployerAbbreviation(string kindOfEmployerName)
        {
            if (!string.IsNullOrEmpty(kindOfEmployerName))
            {
                if (DictionaryHelper.KindOfEmployerNameDictionary.ContainsKey(kindOfEmployerName))
                    return DictionaryHelper.KindOfEmployerNameDictionary[kindOfEmployerName];
            }

            return string.Empty;
        }

        public static string GetKindOfEmployerName(string kindOfEmployerAbbreviation)
        {
            if (!string.IsNullOrEmpty(kindOfEmployerAbbreviation))
            {
                var kindOfEmployerName = DictionaryHelper.KindOfEmployerNameDictionary.FirstOrDefault(x => x.Value == kindOfEmployerAbbreviation).Key;

                if (kindOfEmployerName != null)
                    return kindOfEmployerName;
            }

            return string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
