using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doubler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter firs string: ");
            String str1 = Console.ReadLine();
            Console.Write("Enter second string: ");
            String str2 = Console.ReadLine();
            String resultStr="";
            foreach (var simbol in str1)
            {
                if (!str2.Contains(simbol))
                {
                    resultStr += simbol;
                }
                else
                {
                    resultStr += simbol;
                    resultStr += simbol;
                }
            }
            Console.WriteLine($"Result: {resultStr} \n");

        }
    }
}
