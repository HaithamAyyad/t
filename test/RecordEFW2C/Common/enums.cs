using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Common.Enum
{
    public enum RecordNameEnum
    {
        RCA,
        RCE,
        RCW,
        RCO,
        RCS,
        RCT,
        RCU,
        RCV,
        RCF,
    }

    public enum FieldTypeEnum
    {
        Numerical_RightJustify_Zero,
        Numerical_LeftJustify_Blank,
        UpperCase_LeftJustify_Blank,
        CaseSensitive_LeftJustify,
    }
}
