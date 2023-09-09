using EFW2C.Common.Enums;
using System;
using System.Linq;

namespace EFW2C.Common.Helper
{
    public class EnumHelper
    {
        public static bool IsCountryCodeValid(string str)
        {
            foreach (var countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                if (countryCode.ToString() == str)
                    return true;
            }

            return false;
        }

        public static bool IsMiltaryPostOffice(string state)
        {
            foreach (var zipCode in Enum.GetValues(typeof(MILITARY_POST_OFFICES)))
            {
                if (zipCode.ToString() == state)
                    return true;
            }

            return false;

        }

        public static bool IsTerritorise(string state)
        {
            foreach (var zipCode in Enum.GetValues(typeof(TERRITORIES_AND_POSSESSIONS)))
            {
                if (zipCode.ToString() == state)
                    return true;
            }

            return false;
        }

        public static bool IsUsaState(string state)
        {
            foreach (var stateCode in Enum.GetValues(typeof(StateCodeEnum)))
            {
                if (stateCode.ToString() == state)
                    return true;
            }

            return false;
        }

        public static bool IsStateTerritoriseMiltary(string str)
        {
            return IsUsaState(str) || IsTerritorise(str) || IsMiltaryPostOffice(str);
        }

        public static bool IsValidStateCode(string state, bool value = false)
        {
            foreach (var stateCode in Enum.GetValues(typeof(StateCodeEnum)))
            {
                if (value)
                {
                    if (((int)stateCode).ToString("D2") == state)
                        return true;
                }
                else
                {
                    if (stateCode.ToString() == state)
                        return true;
                }
            }

            return false;
        }

        public static bool IsPreparerCodeVaild(string code)
        {
            return Enum.GetNames(typeof(PreparerCodeEnum)).Any(enumValue => enumValue == code);
        }

        public static bool IsKindOfEmployerValid(string kind)
        {
            return Enum.GetNames(typeof(KindOfEmployerEnum)).Any(enumValue => enumValue == kind);
        }
     
        public static bool IsAgentIndicatorValid(int indicatorValue)
        {
            return Enum.IsDefined(typeof(AgentIndicatorCodeEnum), indicatorValue);
        }

        public static bool IsEmploymentCodeValid(string code)
        {
            return Enum.IsDefined(typeof(EmploymentCodeEnum), code);
        }

        public static bool IsTaxTypeCodeValid(string taxTypeCode)
        {
            return Enum.IsDefined(typeof(TaxTypeCodeEnum), taxTypeCode);
        }
    }
}
