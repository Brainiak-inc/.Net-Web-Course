using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Площадь прямоугольника со сторонами. 
 */

namespace Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int rectangleArea, intLength, intWidth;
                Console.Write("Enter lenght: ");
                string length = Console.ReadLine();
                Console.Write("Enter width: ");
                string width = Console.ReadLine();

                bool resultLength = int.TryParse(length, out intLength);
                bool resultWidth = int.TryParse(width, out intWidth);


                while (!resultLength || !resultWidth)
                {
                    Console.WriteLine("Error! Please, enter integer value!");
                    Console.Write("Enter lenght: ");
                    length = Console.ReadLine();
                    Console.Write("Enter width: ");
                    width = Console.ReadLine();
                    resultLength = int.TryParse(length, out intLength);
                    resultWidth = int.TryParse(width, out intWidth);

                }
                while ((intLength <= 0) || (intWidth <= 0))
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Please, enter correct values: ");
                    Console.Write("Enter lenght: ");
                    length = Console.ReadLine();
                    Console.Write("Enter width: ");
                    width = Console.ReadLine();
                    resultLength = int.TryParse(length, out intLength);
                    resultWidth = int.TryParse(width, out intWidth);

                }

                rectangleArea = intLength * intWidth;

                Console.WriteLine($"Rectangle Area: {rectangleArea}");
                Console.WriteLine("Enter any key...");
                Console.ReadKey();
            }
        }
        
    }
}


