using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.RecordEFW2C.Helpper
{
    public class DictionaryHelper
    {
        public static Dictionary<string, string> UsaStateNameDictionary = new Dictionary<string, string>
        {
            {"Alabama", "AL"},
            {"Alaska", "AK"},
            {"Arizona", "AZ"},
            {"Arkansas", "AR"},
            {"California", "CA"},
            {"Colorado", "CO"},
            {"Connecticut", "CT"},
            {"Delaware", "DE"},
            {"District of Columbia", "DC"},
            {"Florida", "FL"},
            {"Georgia", "GA"},
            {"Hawaii", "HI"},
            {"Idaho", "ID"},
            {"Illinois", "IL"},
            {"Indiana", "IN"},
            {"Iowa", "IA"},
            {"Kansas", "KS"},
            {"Kentucky", "KY"},
            {"Louisiana", "LA"},
            {"Maine", "ME"},
            {"Maryland", "MD"},
            {"Massachusetts", "MA"},
            {"Michigan", "MI"},
            {"Minnesota", "MN"},
            {"Mississippi", "MS"},
            {"Missouri", "MO"},
            {"Montana", "MT"},
            {"Nebraska", "NE"},
            {"Nevada", "NV"},
            {"New Hampshire", "NH"},
            {"New Jersey", "NJ"},
            {"New Mexico", "NM"},
            {"New York", "NY"},
            {"North Carolina", "NC"},
            {"North Dakota", "ND"},
            {"Ohio", "OH"},
            {"Oklahoma", "OK"},
            {"Oregon", "OR"},
            {"Pennsylvania", "PA"},
            {"Rhode Island", "RI"},
            {"South Carolina", "SC"},
            {"South Dakota", "SD"},
            {"Tennessee", "TN"},
            {"Texas", "TX"},
            {"Utah", "UT"},
            {"Vermont", "VT"},
            {"Virginia", "VA"},
            {"Washington", "WA"},
            {"West Virginia", "WV"},
            {"Wisconsin", "WI"},
            {"Wyoming", "WY"}
    };

        public static Dictionary<string, string> EmploymentCodeNameDictionary = new Dictionary<string, string>
        {
            {"941/941-SS", "R"},
            {"Military", "M"},
            {"943", "A"},
            {"944", "F"},
            {"CT-1", "X"},
            {"Hshld. Emp.", "H"},
            { "Medicare govt. emp.", "Q"}
        };

        public static Dictionary<string, string> KindOfEmployerNameDictionary = new Dictionary<string, string>
        {
            {"None apply", "N"},
            {"Federal govt.", "F"},
            {"State/local non-501c", "S"},
            {"501c non-govt.", "T"},
            { "State/local 501c", "Y"},
        };
    }

}
