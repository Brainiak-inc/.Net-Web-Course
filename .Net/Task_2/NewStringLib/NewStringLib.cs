using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewStringLib
{
    public class myString
    {
        public static bool StringComparison(string str1, string str2)
        {

            char[] charArray1 = str1.ToCharArray();
            char[] charArray2 = str2.ToCharArray();

            if (charArray1.Length != charArray2.Length)
            {
                return false;
            }
            for (int i = 0; i < charArray1.Length; i++)
            {
                if (charArray1[i] != charArray2[i])
                {
                    return false;
                }

            }
            return true;
        }
        public static string ConcatString(string String1, string String2)
        {
            int counter = 0;

            char[] charArray1 = String1.ToCharArray();
            char[] charArray2 = String2.ToCharArray();
            char[] charArrayResult = new char[charArray1.Length + charArray2.Length];

            foreach (var i in charArray1)
            {
                charArrayResult[counter] = i;
                counter++;
            }
            foreach (var i in charArray2)
            {
                charArrayResult[counter] = i;
                counter++;
            }

            string resultString = new string(charArrayResult);


            return resultString;
        }
        public static char CharSearch(string String, char symbol)
        {
            char ch = '0';
            char[] charArray = String.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == symbol)
                {
                    ch = symbol;
                    break;
                }
                else
                {
                    ch = '0';
                }
            }

            return ch;
        }

        //I decided, that i have to search not just symbol, but it's index too
        public static int IndexOf(string String, char symbol)
        {
            int indexOfSymbol = 0;
            char[] charArray = String.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == symbol)
                {
                    indexOfSymbol = i;
                    break;
                }
            }
            return indexOfSymbol;
        }

        public static char[] ToChar(string str)
        {
            char[] charArray;

            charArray = str.ToCharArray();

            return charArray;
        }
        public static string NewToString(char[] charArray)
        {
            string result = new string(charArray);
            return result;
        }

    }
}
