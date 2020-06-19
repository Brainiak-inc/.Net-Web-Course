using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Square : Figure
    {
        double perimetr { get; set; }
        double area { get; set; }

        private double sideSquare;

        public double SideSquare
        {
            get
            {
                return SideSquare;
            }
            set
            {
                if (SideSquare > 0)
                {
                    SideSquare = value;
                }
            }
        }

        public Square(double x, double y, double SideSquare) : base(x,y)
        {
            SideSquare = sideSquare;
        }
        public virtual double CalculatePerimetr()
        {
            perimetr = SideSquare * 4;

            return perimetr;
        }
        public virtual double CalculateArea()
        {
            area = SideSquare * SideSquare;

            return area;
        }
        public override string ToString()
        {
            string squareInfo = $"Square has been created. \nPerimetr: {perimetr}. \nArea: {area}. " +
                                  $"\nCoordinate's: X: {X}, Y: {Y}.";

            return squareInfo;
        }
    }
}
