using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace X_mas_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int height;
                Console.Write("Please, enter size of tree: ");
                while (!int.TryParse(Console.ReadLine(), out height) || height <= 0)
                    Console.Write("Please try again: ");
                for (int i = 1; i <= height; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {

                        Console.WriteLine(new string(' ', height - j) + new string('*', j * 2 - 1));
                    }
                }
            }
        }
    }
}
