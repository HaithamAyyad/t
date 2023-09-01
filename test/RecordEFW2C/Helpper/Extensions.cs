using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW2C.Extensions
{
    static class StringExtensions
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
                if (!char.IsUpper(input[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }

    static class ArrayExtensions
    {
        public static bool Compare<T>(this T[] array1, int startPos1, T[] array2, int length)
        {
            if (array1 == null || array2 == null)
            {
                return array1 == array2;
            }

            if (startPos1 < 0 || length <= 0 ||
                startPos1 + length > array1.Length || length > array2.Length)
            {
                throw new ArgumentException("Invalid positions or length.");
            }

            for (int i = 0; i < length; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(array1[startPos1 + i], array2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static class CharArrayExtensions
    {
        public static void Fill(this char[] array, char value, int startPosition, int length)
        {
            for (int i = startPosition; i < length; i++)
            {
                array[i] = value;
            }
        }
    }

}
