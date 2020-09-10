using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] array = Enumerable.Range(0, 1000).ToArray();
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if ((array[i] % 3==0) || (array[i] % 5 == 0))
                {
                    sum += array[i];
                }
            }
            Console.WriteLine($"Sum of array elements: {sum}");
        }
    }
}
