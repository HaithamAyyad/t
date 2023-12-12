using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
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

        public static List<string> GetUsaStateNameList()
        {
            return DictionaryHelper.UsaStateNameDictionary.Keys.ToList();
        }

        public static string GetUsaAbbreviationsStateCode(string name)
        {
            if (DictionaryHelper.UsaStateNameDictionary.ContainsKey(name))
                return DictionaryHelper.UsaStateNameDictionary[name];

            return string.Empty;
        }

        public static bool IsValidStateCode(string state, bool value = false)
        {
            return EnumHelper.IsValidStateCode(state, value);
        }

        public static string GetUsaStateName(string code)
        {
            if (DictionaryHelper.UsaStateNameDictionary.ContainsValue(code))
                return DictionaryHelper.UsaStateNameDictionary.FirstOrDefault(x => x.Value == code).Key;

            return string.Empty;
        }

        public static List<string> GetEmploymentCodeNameList()
        {
            return DictionaryHelper.EmploymentCodeNameDictionary.Keys.ToList();
        }

        public static List<string> GetCountryCodeNameList()
        {
            return Enum.GetNames(typeof(CountryCode)).ToList();
        }

        public static string GetEmploymentCode(string name)
        {
            if (DictionaryHelper.EmploymentCodeNameDictionary.ContainsKey(name))
                return DictionaryHelper.EmploymentCodeNameDictionary[name];

            return string.Empty;
        }

        public static string GetEmploymentCodeName(string code)
        {
            if (DictionaryHelper.EmploymentCodeNameDictionary.ContainsValue(code))
                return DictionaryHelper.EmploymentCodeNameDictionary.FirstOrDefault(x => x.Value == code).Key;

            return string.Empty;
        }

        public static List<string> GetKindOfEmployerNames()
        {
            return DictionaryHelper.KindOfEmployerNameDictionary.Keys.ToList();
        }

        public static string GetKindOfEmployerCode(string name)
        {
            if (DictionaryHelper.KindOfEmployerNameDictionary.ContainsKey(name))
                return DictionaryHelper.KindOfEmployerNameDictionary[name];

            return string.Empty;
        }

        public static string GetKindOfEmployerName(string code)
        {
            if (DictionaryHelper.KindOfEmployerNameDictionary.ContainsValue(code))
                return DictionaryHelper.KindOfEmployerNameDictionary.FirstOrDefault(x => x.Value == code).Key;

            return string.Empty;
        }

        public static List<string> GetPreparerCodeNameList()
        {
            return DictionaryHelper.PreparerCodeDictionary.Keys.ToList();
        }

        public static string GetPreparerCodeName(string code)
        {
            if (DictionaryHelper.PreparerCodeDictionary.ContainsValue(code))
                return DictionaryHelper.PreparerCodeDictionary.FirstOrDefault(x => x.Value == code).Key;

            return string.Empty;
        }

        public static string GetPreparerCode(string name)
        {
            if (DictionaryHelper.PreparerCodeDictionary.ContainsKey(name))
                return DictionaryHelper.PreparerCodeDictionary[name];

            return string.Empty;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
