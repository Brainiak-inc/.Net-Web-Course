using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace VALIDATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            String str = Console.ReadLine();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() != str[i].ToString().ToUpper())
                {
                    str.Replace(str[i].ToString(), str[i].ToString().ToUpper(),i,1);
                }
                while (true)
                {
                    if (str[i].ToString() == "." ||
                        str[i].ToString() == "?" ||
                        str[i].ToString() == "!")
                    {
                        i += 1;
                        break;
                    }
                    i++;
                }
            }
            Console.WriteLine(str);
        }
    }
}
