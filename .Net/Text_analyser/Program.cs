using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('*', 25)+'\n');
            Console.WriteLine("Text analyser\n");
            Console.WriteLine(new string('*', 25)+'\n');

            Console.WriteLine("Please, enter text below: ");

            Text_analysis analyser = new Text_analysis(Console.ReadLine());

            Console.WriteLine(new string('*', 25) + '\n');

            Console.WriteLine(analyser.ToString());

            Console.WriteLine(new string('*', 25) + '\n');

            analyser.SetStatus();

            Console.WriteLine(new string('*', 25) + '\n');







        }
    }
}
