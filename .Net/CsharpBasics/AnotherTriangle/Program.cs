using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int height;
                Console.Write("Enter triangle's height: ");
                string strHeight = Console.ReadLine();
                bool result = int.TryParse(strHeight, out height);
                while (!result)
                {
                    Console.Write("Please, enter correct value: ");
                    strHeight = Console.ReadLine();
                    result = int.TryParse(strHeight, out height);
                }
                while (height <= 0)
                {
                    Console.WriteLine($"You entered {height}, please, enter pozitive value: ");
                    height = int.Parse(Console.ReadLine());
                }
                AnotherTriangle(height);
               
            }
        }
        static void AnotherTriangle(int height)
        {
            for (int i = 1; i <= height; i++)
            {
                Console.WriteLine(new string(' ', height - i) + new string('*', i * 2 - 1));
            }
        }
    }
}

