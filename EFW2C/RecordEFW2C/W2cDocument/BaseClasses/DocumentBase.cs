using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public abstract class DocumentBase
    {
        protected bool _isLocked;
        public DocumentBase()
        {
        }
        public bool Lock(bool value)
        {
            if (value)
            {
                Prepare();

                if (!Verify())
                    return false;
            }
            else
            {
            }

            _isLocked = value;

            return true;
        }

        private void Prepare()
        {
        }

        public bool IsLocked()
        {
            return _isLocked;
        }

        public abstract bool Verify();
    }
}
