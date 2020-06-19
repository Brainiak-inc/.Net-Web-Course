using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{

    class ValueSetter
    {
        static Figure figure;
        static double value;

        static private void setXY()
        {
            Console.WriteLine("Enter X: ");
            bool validatorX = double.TryParse(Console.ReadLine(), out value);
            if (validatorX == false)
            {
                Console.WriteLine("Enter vozitiv value: ");
                validatorX = double.TryParse(Console.ReadLine(), out value);
                figure.X = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter vozitiv value: ");
                validatorX = double.TryParse(Console.ReadLine(), out value);
                figure.X = value;
            }

            Console.WriteLine("Enter vozitiv value: ");
            bool validatorY = double.TryParse(Console.ReadLine(), out value);

            if (validatorY == false)
            {
                Console.WriteLine("Enter vozitiv value: ");
                validatorY = double.TryParse(Console.ReadLine(), out value);
                figure.Y = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter vozitiv value: ");
                validatorY = double.TryParse(Console.ReadLine(), out value);
                figure.Y = value;
            }

        }
        static private void setInsideRadius(Circle figure)
        {
            Console.WriteLine("Enter radius: ");
            bool validatorInsideRadius = double.TryParse(Console.ReadLine(), out value);

            if (validatorInsideRadius == false)
            {
                Console.WriteLine("Enter vozitiv value: ");
                validatorInsideRadius = double.TryParse(Console.ReadLine(), out value);
                figure.InsideRadius = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter vozitiv value: ");
                validatorInsideRadius = double.TryParse(Console.ReadLine(), out value);
                figure.InsideRadius = value;
            }
        }


        public static Figure constructCircle() 
        {
            setXY();
            figure = new Circle();
            setInsideRadius((Circle)figure);
            return figure;
        }
    }
}
