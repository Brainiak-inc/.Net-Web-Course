using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2._1._OOP_okay_okay_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Comparison
            string str_1, str_2;

            Console.Write("Enter string 1: ");
            str_1 = Console.ReadLine();

            Console.Write("Enter string 2: ");
            str_2 = Console.ReadLine();

            Console.WriteLine(myString.StringComparison(str_1, str_2));

            //Symbol searching 
            Console.Write("Enter new sentence: \n");
            string sentence = Console.ReadLine();

            Console.Write("Enter only one symbol, which you want to find in your sentence: ");
            char symbol = char.Parse(Console.ReadLine());
            Console.WriteLine($"Here's your sybmbol: {myString.CharSearch(sentence, symbol)}");
            Console.WriteLine($"Index of your symbol: {myString.IndexOf(sentence, symbol)}");

        }    
    }
    class myString
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
        //public static string ConcatString(string String1, string String2)
        //{
        //    string resultString;
        //    char[] charArray1 = String1.ToCharArray();
        //    char[] charArray2 = String2.ToCharArray();



        //}
        public static char CharSearch(string String, char symbol)
        {
            char ch = '0';
            char[] charArray = String.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if(charArray[i] == symbol)
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
        //so here we go!
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
    }
}
