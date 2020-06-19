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
                Console.WriteLine("Enter positiv value: ");
                validatorX = double.TryParse(Console.ReadLine(), out value);
                figure.X = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorX = double.TryParse(Console.ReadLine(), out value);
                figure.X = value;
            }
            else
            {
                figure.X = value;
            }

            Console.WriteLine("Enter Y: ");
            bool validatorY = double.TryParse(Console.ReadLine(), out value);

            if (validatorY == false)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorY = double.TryParse(Console.ReadLine(), out value);
                figure.Y = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorY = double.TryParse(Console.ReadLine(), out value);
                figure.Y = value;
            }
            else
            {
                figure.Y = value;
            }

        }
        static private void setInsideRadius(Circle figure)
        {
            Console.WriteLine("Enter inside radius: ");
            bool validatorInsideRadius = double.TryParse(Console.ReadLine(), out value);

            if (validatorInsideRadius == false)
            {
                Console.WriteLine("Enter pozitiv value: ");
                validatorInsideRadius = double.TryParse(Console.ReadLine(), out value);
                figure.InsideRadius = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorInsideRadius = double.TryParse(Console.ReadLine(), out value);
                figure.InsideRadius = value;
            }
            else
            {
                figure.InsideRadius = value;
            }
        }
        static private void setoutsideRadius(Ring figure)
        {
            Console.WriteLine("Enter outside radius: ");
            bool validatorOutsideRadius = double.TryParse(Console.ReadLine(), out value);

            if (validatorOutsideRadius == false)
            {
                Console.WriteLine("Enter pozitiv value: ");
                validatorOutsideRadius = double.TryParse(Console.ReadLine(), out value);
                figure.OutsideRadius = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorOutsideRadius = double.TryParse(Console.ReadLine(), out value);
                figure.OutsideRadius = value;
            }else if(figure.InsideRadius > value)
            {
                Console.WriteLine("Outer radius have to be bigger, then inner, try again: ");
                validatorOutsideRadius = double.TryParse(Console.ReadLine(), out value);
                figure.OutsideRadius = value;
            }
            else
            {
                figure.OutsideRadius = value;
            }
        }
        static private void setLength(Line figure)
        {
            Console.Write("Enter length: ");
            bool validatorLength = double.TryParse(Console.ReadLine(), out value);

            if (validatorLength == false)
            {
                Console.WriteLine("Enter pozitiv value: ");
                validatorLength = double.TryParse(Console.ReadLine(), out value);
                figure.Length = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorLength = double.TryParse(Console.ReadLine(), out value);
                figure.Length = value;
            }
            else
            {
                figure.Length = value;
            }

        }
        static private void setSideAB(Rectangle figure)
        {
            Console.Write("Enter side A: ");
            bool validatorA = double.TryParse(Console.ReadLine(), out value);

            if (validatorA == false)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorA = double.TryParse(Console.ReadLine(), out value);
                figure.SideA = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorA = double.TryParse(Console.ReadLine(), out value);
                figure.SideA = value;
            }
            else
            {
                figure.SideA = value;
            }

            Console.Write("Enter side A: ");
            bool validatorB = double.TryParse(Console.ReadLine(), out value);

            if (validatorB == false)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorB = double.TryParse(Console.ReadLine(), out value);
                figure.SideB = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorB = double.TryParse(Console.ReadLine(), out value);
                figure.SideB = value;
            }
            else
            {
                figure.SideB = value;
            }
        }
        static private void setSquareSide(Square figure)
        {
            Console.Write("Enter square side: ");
            bool validatorSide = double.TryParse(Console.ReadLine(), out value);

            if (validatorSide == false)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorSide = double.TryParse(Console.ReadLine(), out value);
                figure.SideSquare = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorSide = double.TryParse(Console.ReadLine(), out value);
                figure.SideSquare = value;
            }
            else
            {
                figure.SideSquare = value;
            }
        }
        static private void setTriangleSides(Triangle figure)
        {
            Console.Write("Enter side A: ");
            bool validatorA = double.TryParse(Console.ReadLine(), out value);

            if (validatorA == false)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorA = double.TryParse(Console.ReadLine(), out value);
                figure.SideA = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorA = double.TryParse(Console.ReadLine(), out value);
                figure.SideA = value;
            }
            else
            {
                figure.SideA = value;
            }

            Console.Write("Enter side B: ");
            bool validatorB = double.TryParse(Console.ReadLine(), out value);

            if (validatorB == false)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorB = double.TryParse(Console.ReadLine(), out value);
                figure.SideB = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorB = double.TryParse(Console.ReadLine(), out value);
                figure.SideB = value;
            }
            else
            {
                figure.SideB = value;
            }

            Console.Write("Enter side C: ");
            bool validatorC = double.TryParse(Console.ReadLine(), out value);

            if (validatorC == false)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorC = double.TryParse(Console.ReadLine(), out value);
                figure.SideC = value;
            }
            else if (value <= 0)
            {
                Console.WriteLine("Enter positiv value: ");
                validatorC = double.TryParse(Console.ReadLine(), out value);
                figure.SideC = value;
            }
            else
            {
                figure.SideC = value;
            }
        }


        public static Figure constructCircle() 
        {
            figure = new Circle();
            setXY(); 
            setInsideRadius((Circle)figure);
            return figure;
        }
        public static Figure constructRing()
        {
            figure = new Ring();
            setXY();
            setInsideRadius((Ring)figure);
            setoutsideRadius((Ring)figure);
            return figure;
        }
        public static Figure constructRound()
        {
            figure = new Round();
            setXY();
            setInsideRadius((Round)figure);
            return figure;

        }
        public static Figure constructLine()
        {
            figure = new Line();
            setXY();
            setLength((Line)figure);
            return figure;
        }
        public static Figure constructRectangle()
        {
            figure = new Rectangle();
            setXY();
            setSideAB((Rectangle)figure);
            return figure;

        }
        public static Figure constructSquare()
        {
            figure = new Square();
            setXY();
            setSquareSide((Square)figure);
            return figure;
        }
        public static Figure constructTriangle()
        {
            figure = new Triangle();
            setXY();
            setTriangleSides((Triangle)figure);
            return figure;
        }

    }
}
