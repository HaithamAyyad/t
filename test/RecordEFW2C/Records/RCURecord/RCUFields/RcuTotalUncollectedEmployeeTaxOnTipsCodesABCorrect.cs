using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : 
    //Reviewed by : 

    public class RcuTotalUncollectedEmployeeTaxOnTipsCodesABCorrect : SumFieldCorrect
    {
        public RcuTotalUncollectedEmployeeTaxOnTipsCodesABCorrect(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 55;
            _length = 15;
        }
    }
}

