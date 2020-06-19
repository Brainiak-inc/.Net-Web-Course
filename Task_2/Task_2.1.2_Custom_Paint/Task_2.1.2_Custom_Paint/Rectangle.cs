using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Rectangle : Figure
    {
        double perimetr { get; set; }
        double area { get; set; }

        private double sideA;
        private double sideB;

        public double SideA
        {
            get
            {
                return SideA;
            }
            set
            {
                if (SideA > 0)
                {
                    SideA = value;
                }
            }
        }
        public double SideB
        {
            get
            {
                return SideB;
            }
            set
            {
                if (SideB > 0)
                {
                    SideB = value;
                }
            }
        }
        public Rectangle(double x, double y, double SideA, double SideB) : base(x, y)
        {
            sideA = SideA;
            sideB = SideB;
        }
        public virtual double CalculatePerimetr()
        {
            perimetr = (sideA + sideB) * 2;

            return perimetr;
        }
        public virtual double CalculateArea()
        {
            area = sideA * sideB;

            return area;
        }
        public override string ToString()
        {
            string rectangleInfo = $"Rectangle has been created. \nPerimetr: {perimetr}. \nArea: {area}. " +
                                  $"\nCoordinate's: X: {X}, Y: {Y}.";

            return rectangleInfo;
        }
    }
}
