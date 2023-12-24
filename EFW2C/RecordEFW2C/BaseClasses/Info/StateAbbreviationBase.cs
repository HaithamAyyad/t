using System;
using EFW2C.Common.Enums;
using EFW2C.Common.Helper;
using EFW2C.Extensions;
using EFW2C.Languages;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : Hsa 9-2-2023
    //Reviewed by : 

    internal abstract class StateAbbreviationBase : StateBase
    {
        public StateAbbreviationBase(RecordBase record, string data)
            : base(record, data)
        {
            _pos = -1;
            _length = -1;
        }

        public override abstract FieldBase Clone(RecordBase record);

        public override bool Verify()
        {
            if (!base.Verify())
                return false;

            if (!string.IsNullOrWhiteSpace(DataInRecordBuffer()))
            {
                var foreignStateProvinceClassName = $"{_record.ClassName.Substring(0, 3)}ForeignStateProvince";
                if (!IsFieldNullOrWhiteSpace(_record.GetField(foreignStateProvinceClassName)))
                {
                    throw new Exception(Error.Instance.GetError(ClassDescription, Error.Instance.MustBeBlankOtherwiseFill, $"{foreignStateProvinceClassName.Substring(3)} Blank"));
                }
            }

            return true;
        }
    }
}
