using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.W2cDocument
{
    public class W2cEmployeeOptional : DocumentPart
    {
        public W2cEmployeeOptional(W2cDocument document)
            : base(document)
        {

        }

        public override bool Verify()
        {
            throw new NotImplementedException();
        }
        protected override Dictionary<string, string> CreateMapPropFieldDictionay()
        {
            var mapDictionary = new Dictionary<string, string>();

            return mapDictionary;
        }
    }
}
