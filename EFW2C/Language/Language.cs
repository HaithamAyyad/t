using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Resource.Language
{
    public class Language
    {
        private static Language _instance;
        private static ResourceManager _descpitionDesourceManager;
        private Language()
        {
            _descpitionDesourceManager = new ResourceManager("EFW2C.Resources.ResourceDescription", typeof(Language).Assembly);
        }

        public static Language Instance
        {
            get { return (_instance == null) ? _instance = new Language() : _instance; }
        }

        public string LoadDescpitionString(string str)
        {
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

            return descriptionStr;
        }
    }
}
