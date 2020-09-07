using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Averages
{
    class Program
    {
        static void Main(string[] args)
        {
            int AverageLength, count;
            count = 0;
            Console.Write("Please, enter a sentence: ");
            String str = Console.ReadLine();
            String[] words = str.Split(new[] {' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in words)
            {
                count += item.Length;
            }
            AverageLength = count / words.Length; //Результат в виде целого числа

            Console.WriteLine($"Average word length: { AverageLength}");
        }
    }
}
