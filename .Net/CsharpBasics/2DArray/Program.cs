using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[5, 5];
            int height, width;
            Random intRand = new Random();;
            height = array.GetLength(0);
            width = array.GetLength(1);
            Console.WriteLine("Origin array: \n");
            for (int y = 0; y < height; y++) //Добавляет в массив случайные (или псевдослучайные?) числа 
            {
                for (int x = 0; x < width; x++)
                {
                    array[y, x] = intRand.Next(-20, 20);
                }
            }
            for (int y = 0; y < height; y++)//Выводит массив
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write($"{array[y,x]} \t");
                }
                Console.WriteLine();
            }
            int sum = 0;
            for (int y = 0; y < height; y++)//Считает сумму элемeнтов, стоящих на четных позициях  
            {
                for (int x = 0; x < width; x++)
                {
                    if ((y+x) % 2 == 0)
                    {
                        sum += array[y, x];
                    }
                }

            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
