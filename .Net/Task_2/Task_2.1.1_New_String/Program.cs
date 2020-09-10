using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewStringLib;

namespace Task_2._1._OOP_okay_okay_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Comparison
            string str_1, str_2;
            char symbol;

            Console.Write("Enter string 1: ");
            str_1 = Console.ReadLine();

            Console.Write("Enter string 2: ");
            str_2 = Console.ReadLine();

            Console.WriteLine(myString.StringComparison(str_1, str_2));

            //Symbol searching 
            Console.Write("Enter new sentence: \n");
            string sentence = Console.ReadLine();

            Console.Write("Enter only one symbol, which you want to find in your sentence: ");

            bool symbolValidation = char.TryParse(Console.ReadLine(), out symbol);

            while (symbolValidation == false)
            {
                Console.WriteLine("Enter correct symbol: ");
                symbolValidation = char.TryParse(Console.ReadLine(), out symbol);
            }
            Console.WriteLine($"Here's your sybmbol: {myString.CharSearch(sentence, symbol)}");
            Console.WriteLine($"Index of your symbol: {myString.IndexOf(sentence, symbol)}");

            //Concatanation method
            Console.WriteLine("Concatanating: ");
            Console.Write("Concatenated: ");
            string str_3 =  myString.ConcatString("Hello ", "World");
            Console.WriteLine(str_3);
            //Convert char array to string
            Console.WriteLine();
            char[] testArray = { 'f','g','t' };
            string testStr = myString.NewToString(testArray);
            Console.WriteLine(testStr);
            

        }    
    }
}
