using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LOWERCASE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            String str = Console.ReadLine();
            var wordsArray = str.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            for (int i = 0; i < wordsArray.Length; i++)
            {
                if (Char.IsLower(wordsArray[i][0]))
                {
                    count++;
                }
            }
            Console.WriteLine($"Number of low words: {count}");
        }
    }
}
