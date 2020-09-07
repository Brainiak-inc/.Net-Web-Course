using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            Random RandomInt = new Random();
            array = new int[10];
            Console.WriteLine("Array with random values: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = RandomInt.Next(0, 1000);
                Console.WriteLine(array[i]);
            }
            int[] NewArray = SelectionSort(array);
            Console.WriteLine("Sorted array: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(NewArray[i]);
            }
            Console.WriteLine($"Max array value: {NewArray[9]}");
            Console.WriteLine($"Min array value: {NewArray[0]}");
        }
        static int[] SelectionSort(int[] array)
        {
            int min, temp;
            int length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;
                }
            }
            return array;
        }
    }
}
