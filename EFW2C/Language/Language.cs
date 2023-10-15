using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Languages
{
    public class Language
    {
        private static Language _instance;
        private static ResourceManager _descpitionDesourceManager;
        private static ResourceManager _exceptionsManager;
        private Language()
        {
            _descpitionDesourceManager = new ResourceManager("EFW2C.Resources.ResourceDescription", typeof(Language).Assembly);
            _exceptionsManager = new ResourceManager("EFW2C.Resources.ResourceExceptions", typeof(Language).Assembly);
        }

        public static Language Instance
        {
            get { return (_instance == null) ? _instance = new Language() : _instance; }
        }

        public string LoadDescpitionString(string str)
        {
            var old = str;
            var descriptionStr = "{Description-Not-Defined}";
            try
            {
                str = _descpitionDesourceManager.GetString(str);
                if (str != null)
                {
                    descriptionStr = "{" + str + "}";
                }
            }
            catch
            {
            }

            if(str == null)
            {

            }
            if(str != null && !str.Contains(old.Substring(3)))
            {

            }

            return descriptionStr;
        }
        public string LoadExceptionString(string str)
        {
            var descriptionStr = "{Exception-Not-Defined}";
            try
            {
                str = _descpitionDesourceManager.GetString(str);
                if (str != null)
                    descriptionStr = str;
            }
            catch
            {
            }

            if(str == null)
            {

            }

            return descriptionStr;
        }
    }
}
