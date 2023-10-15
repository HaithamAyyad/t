using EFW2C.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Extensions
{
    public static class StringExtensions
    {
        public static char[] ToCharArray(this string str)
        {
            char[] charArray = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                charArray[i] = str[i];
            }
            return charArray;
        }
        public static bool IsUpper(this string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (!(char.IsUpper(c) || char.IsDigit(c) || char.IsWhiteSpace(c)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDigit(this string input, char[] excludeList)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c) && !excludeList.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static string ReplaceFirstOccurrence(this string original, string oldValue, string newValue)
        {
            int index = original.IndexOf(oldValue);

            if (index != -1)
            {
                return original.Substring(0, index) + newValue + original.Substring(index + oldValue.Length);
            }

            return original;
        }
    }

    public static class CharExtensions
    {
        public static bool IsDigitOrSpace(this char c)
        {
            return char.IsDigit(c) || c == ' ';
        }
    }
    public static class CharArrayExtensions
    {
        public static void Fill(this char[] array, char value, int pos, int length)
        {
            for (int i = pos; i < pos + length; i++)
            {
                array[i] = value;
            }
        }
    }

}
