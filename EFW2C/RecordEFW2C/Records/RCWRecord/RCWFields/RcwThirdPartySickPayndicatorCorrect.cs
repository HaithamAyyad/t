using System;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 9-9-2023
    //Reviewed by : 

    public class RcwThirdPartySickPayndicatorCorrect : FieldCorrect
    {
        public RcwThirdPartySickPayndicatorCorrect(RecordBase record, string data)
            : base(record, data)
        {
            _pos = 1007;
            _length = 1;
        }

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            var localData = DataInRecordBuffer();

            if (!(localData == "1" || localData == "0"))
                throw new Exception($"{ClassName}: data only can be zero or one");

            if (_record.GetFields(typeof(RcwSocialSecurityNumberCorrect).Name) == null)
                throw new Exception($"{ClassName}: social security field must be provided");

            if (_record.GetFields(typeof(RcwEmployeeFirstNameCorrect).Name) == null)
                throw new Exception($"{ClassName}: employee first name field must be provided");

            if (_record.GetFields(typeof(RcwEmployeeLastNameCorrect).Name) == null)
                throw new Exception($"{ClassName}: employee last name field must be provided");

            return true;
        }
    }
}
