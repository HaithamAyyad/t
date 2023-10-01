using EFW2C.Manager;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cDocument
    {
        private W2cSubmitter _submitter;
        private List<W2cEmployer> _employerList;
        private RecordManager _manager;

       internal RecordManager Manager { get { return _manager; } }

        public W2cDocument()
        {
            _manager = new RecordManager();
            _employerList = new List<W2cEmployer>();
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

            Manager.AddRceRecord((RceRecord)employer.Record);

        }

        public void SaveDocument(string fileName)
        {
        }
    }
}
