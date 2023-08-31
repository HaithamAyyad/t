using System;

using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    public class RcaIdentifierField : FieldBase
    {
        public RcaIdentifierField(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 0;
            _length = 3;
            ClassName = GetType().Name;
        }

        public override void Write()
        {
            if(!VerifyWrite())
                return;

            var data = _record.Name.ToUpper().ToCharArray();
            Array.Copy(data, 0, _record.RecordBuffer, _pos, _length);
        }
            
        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!_data. IsUpper())
                throw new Exception($"{ClassName} Field is not upper case");

            if(!_record.RecordBuffer.Compare(_pos, _record.Name.ToCharArray(), _length))
                throw new Exception($"{ClassName} Field must be {_record.Name}");

            return true;
        }
    }
}
