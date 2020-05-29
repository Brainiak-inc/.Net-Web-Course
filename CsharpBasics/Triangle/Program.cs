using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int height;
                Console.Write("Enter triangle's height: ");
                string str = Console.ReadLine();
                bool result = int.TryParse(str, out height);
                while(!result)
                {
                    Console.WriteLine("Error! Please, enter correct value.");
                    Console.Write("Enter triangle's height: ");
                    str = Console.ReadLine();
                    result = int.TryParse(str, out height);

                }
                while(height <= 0)
                {
                    Console.WriteLine("Error! Please, enter correct value.");
                    Console.Write("Enter triangle's height: ");
                    str = Console.ReadLine();
                    result = int.TryParse(str, out height);
                }
                Triangle(height);
                
                
            }
            
        }
        static void Triangle(int height)
        {
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
        }
    }
}
