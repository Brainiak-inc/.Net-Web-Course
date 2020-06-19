using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;

namespace Task_2._1._2_Custom_Paint
{
    class Program
    {
        static Figure figure;
        static void Main(string[] args)
        {
            figure = ValueSetter.constructCircle();
            Console.WriteLine(figure);
           
        }
    }
    
}
