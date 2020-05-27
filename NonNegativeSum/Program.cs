using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonNegativeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            int PozitiveNumSum = 0;
            Random RandomInt = new Random();
            array = new int[20];
            Console.Write("\n\tOriginal array: ");//Мне показалось, что с табуляцией и переносом строки выглядит читабельнее 
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = RandomInt.Next(-9, 10);
                Console.Write($"{array[i]} ");
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    PozitiveNumSum += array[i];
                }
            }
            Console.WriteLine($"\n\tSum of pozitive array values: {PozitiveNumSum}\n");
        }
    }
}
