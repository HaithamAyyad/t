using EFW2C.Common.Enum;

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
            foreach (var field in _fields)
            {
                if (!field.Verify())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
