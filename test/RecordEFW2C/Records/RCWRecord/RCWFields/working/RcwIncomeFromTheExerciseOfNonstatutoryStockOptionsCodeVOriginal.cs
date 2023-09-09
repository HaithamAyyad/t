using System;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Extensions;
using EFW2C.Records;

namespace EFW2C.Fields
{
    //Created by : HSA 9-9-2023
    //Reviewed by : 

    public class RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal : MoneyOriginal
    {
        public RcwIncomeFromTheExerciseOfNonstatutoryStockOptionsCodeVOriginal(RecordBase record)
            : base(record, Constants.WhiteSpaceString)
        {
            _pos = 727;
            _length = 11;
        }
    }
}
