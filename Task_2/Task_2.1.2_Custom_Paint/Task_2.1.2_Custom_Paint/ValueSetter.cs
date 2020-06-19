using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class ValueSetter
    {
        public void FigureSetter()
        {
            Figure figure = new Figure(double x, double y);
        }

        public void SetCircle()
        {
            int radius;

            Console.WriteLine("Enter following parameters: ");

            Console.Write("Enter radius: ");

            bool radValidator = int.TryParse(Console.ReadLine(), out radius);
            if (radValidator == false)
            {
                Console.WriteLine("Inter integer value: ");
                radValidator = int.TryParse(Console.ReadLine(), out radius);
            }
            else if (radius <= 0)
            {
                Console.WriteLine("Enter pozitive valu: ");
                radValidator = int.TryParse(Console.ReadLine(), out radius);
            }



        }
    }
}
