using EFW2C.Common.Enum;
using EFW2C.Fields;

namespace EFW2C.Records
{
    public class RCARecord : RecordBase
    {
        public RCARecord()
        {
            Name = RecordName.RCA.ToString();
        }
        public override void Write()
        {
            foreach (var field in _fields)
                field.Write();
        }
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            foreach (var field in _fields)
            {
                if (!field.Verify())
                {
                    return false;
                }
            }
            return true;
        }

        protected override void CreateRequiredFields()
        {
            _requiredFields.Add(new RcaIdentifierField(null, null));
            _requiredFields.Add(new RcaSubmitterEinField(null, null));
        }
    }
}
