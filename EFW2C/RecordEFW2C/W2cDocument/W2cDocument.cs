using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cDocument : DocumentBase
    {
        private W2cSubmitter _submitter;
        private List<W2cEmployer> _employerList;

        public W2cDocument()
        {
            _employerList = new List<W2cEmployer>();
        }

        public override bool Verify()
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

        public void SetSubmitter(W2cSubmitter submitter)
        {
            if (!submitter.IsLocked())
                throw new Exception($"Submitter must be locked");

            _submitter = submitter;
        }

        public void AddEmployer(W2cEmployer employer)
        {
            if (!employer.IsLocked())
                throw new Exception($"Employer must be locked");

            //
            // More checking is needed.
            //

            _employerList.Add(employer);

        }

        internal void Remove(DocumentPart documentPart)
        {
            if (documentPart is W2cSubmitter)
                _submitter = null;

            if (documentPart is W2cEmployer employer)
                _employerList.RemoveAll(item => item == employer);

        }

        public void SaveDocument(string fileName)
        {
            ManagerSingleton.GetInstance().GetRecordManager().WriteToFile(fileName);
        }
    }
}
