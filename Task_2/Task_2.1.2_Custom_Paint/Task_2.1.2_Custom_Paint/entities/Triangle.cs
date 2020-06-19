using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Triangle : Figure
    {
        private double perimetr { get; set; }
        private double area { get; set; }

        private double triangleSideA;
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
        private double triangleSideB;
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

        private double triangleSideC;
        public double SideC
        {
            get
            {
                return SideC;
            }
            set
            {
                if (SideC > 0)
                {
                    SideC = value;
                }
            }
        }
        //public Triangle(double x, double y, double triangleSideA, double triangleSideB, double triangleSideC) : base(x,y)
        //{
        //    SideA = triangleSideA;
        //    SideB = triangleSideB;
        //    SideC = triangleSideC;
        //}

        public virtual double CalculatePerimetr()
        {
            double perimetr = SideA + SideB + SideC;

            return perimetr;
        }
        public virtual double CalculateArea()
        {
            double area = Math.Sqrt(perimetr * (perimetr - SideA) * (perimetr - SideB) * (perimetr - SideC));

            return area;
        }
        public override string ToString()
        {
            CalculatePerimetr();
            CalculatePerimetr();

            string triangleInfo = $"Triangle has been created. \nPerimetr: {perimetr}. \nArea: {area}. " +
                                  $"\nCoordinate's: X: {X}, Y: {Y}.";

            return triangleInfo;
        }
    }
}
