using EFW2C.Common.Enum;
using EFW2C.Fields;

namespace EFW2C.Records
{
    public class RCARecord : RecordBase
    {
        public RCARecord()
        {
            RecordName = RecordNameEnum.RCA.ToString();
        }
        protected override void CreateRequiredFields()
        {
            _requiredFields.Clear();

            _requiredFields.Add(new RcaIdentifierField(null, null));
            _requiredFields.Add(new RcaSubmitterEinField(null, null));
            _requiredFields.Add(new RcaUserIdentification(null, null));
        }
    }
}
