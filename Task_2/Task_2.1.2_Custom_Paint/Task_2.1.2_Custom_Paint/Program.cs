using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;

namespace Task_2._1._2_Custom_Paint
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose your figure: ");

                Console.Write("1. Circle \n2. Round \n3. Ring \n4. Line \n5. Square " +
                    "\n6. Rectangle \n7. Square \n8. Triangle");

                int chose = int.Parse(Console.ReadLine());

                if (chose == 1 || chose == 2 || chose == 3)
                {

                }

                switch (chose)
                {
                    case 1:
                        Circle circle = new Circle();
                }
            }
           
        }
    }
    
}
