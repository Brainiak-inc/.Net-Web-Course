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
            string str_1, str_2;
            Console.WriteLine("Enter string 1: ");

            str_1 = Console.ReadLine();
            Console.WriteLine("Enter string 2: ");

            str_2 = Console.ReadLine();

            Console.WriteLine(myString.StringComparison(str_1, str_2));


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
    }
}
