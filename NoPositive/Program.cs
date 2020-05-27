using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NoPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            int height, width, page;
            int[,,] array = new int[3, 4, 4];
            Random intRand = new Random();
            page = array.GetLength(0);
            height = array.GetLength(1);
            width = array.GetLength(2);
            for (int z = 0; z < page; z++)//Заполнение массива
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        array[z, y, x] = intRand.Next(-10, 20); 
                    }
                }
            }
            Console.WriteLine("Origin array: ");
            for (int z = 0; z < page; z++)//Вывод массива на консоль
            {
                Console.WriteLine($"Page: {z + 1}");
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Console.Write($"{array[z,y,x]} \t");
                    }
                    Console.WriteLine();
                }
            }
            for (int z = 0; z < page; z++)//Проверка элементов массива на положительность и замена положительных нулями 
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (array[z,y,x] >= 0)
                        {
                            array[z, y, x] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("\nChanged array - zeros instead pozitiv values: \n");
            for (int z = 0; z < page; z++)//Вывод ИЗМЕНЕННОГО массива на консоль - нули вместо положительных чисел 
            {
                Console.WriteLine($"Page: {z + 1}");
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Console.Write($"{array[z, y, x]} \t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
