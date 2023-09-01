using EFW2C.Common.Enum;
using EFW2C.Fields;

namespace EFW2C.Records
{
    public class RecordTemplate : RecordBase
    {
        public RecordTemplate()
        {
            RecordName = null;
        }
        protected override void CreateRequiredFields()
        {
            _requiredFields.Clear();

            //_requiredFields.Add(new RcaIdentifierField(null, null));
        }
    }
}
