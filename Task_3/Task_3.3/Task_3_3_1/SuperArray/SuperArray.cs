using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SuperArray
{
    public static class SuperArray
    {
        public static int[] Extension(this int[] array, Func<int, int> func)
        {
            if (array == null || func == null)
            {
                throw new ArgumentNullException("You've got a null argument");
            }
            else
            {
                return array.Select(item => func(item)).ToArray();
            }
        }
        public static int NewSum(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Entered array is null");
            }
            int sum = 0;
            array.Select(item => sum += item);

            return sum;
        }
        public static double NewAverage(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Entered array is null");
            }
            return array.NewSum() / array.Length;
        }
        public static double NewAverage<T>(this T[] array) where T: struct
        {
            List<Type> allowedTypes = new List<Type>()
            {
                typeof(Int16[]),
                typeof(Int32[]),
                typeof(Single[]),
                typeof(Double[])
            };
            if (!allowedTypes.Contains(array.GetType()))
            {
                return default;
            }
            double sum = 0;

            foreach(string item in array.Select(item => item.ToString()))
            {
                Double.TryParse(item, out double temp);
                sum += temp;
            }
            return sum;
        }
        public static T FrequentlyUse<T>(this T[] array) where T: struct
        {
            if (array == null)
            {
                throw new ArgumentNullException("Entered array is null");
            }
            return array.OrderBy(item => item).GroupBy(item => item).OrderByDescending(item => item.Count()).FirstOrDefault().Key;
        }
        public static double NewSum<T>(this T[] array) where T: struct
        {
            List<Type> allowedTypes = new List<Type>()
            {
                typeof(Int16[]),
                typeof(Int32[]),
                typeof(Single[]),
                typeof(Double[])
            };
            if (array == null)
            {
                throw new ArgumentNullException("Entered array is null");
            }
            if (!allowedTypes.Contains(array.GetType()))
            {
                return default;
            }
            double sum = 0;
            foreach (string item in array.Select(item => item.ToString()))
            {
                Double.TryParse(item, out double temp);
                sum += temp;
            }
            return sum;
        }
    }
}
