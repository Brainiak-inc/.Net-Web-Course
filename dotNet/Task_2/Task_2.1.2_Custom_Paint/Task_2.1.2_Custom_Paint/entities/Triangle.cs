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

        private double triangleSideA;
        public double SideA
        {
            get
            {
                return triangleSideA;
            }
            set
            {
                triangleSideA = value;
            }
        }
        private double triangleSideB;
        public double SideB
        {
            get
            {
                return triangleSideB;
            }
            set
            {
                triangleSideB = value;
            }
        }

        private double triangleSideC;
        public double SideC
        {
            get
            {
                return triangleSideC;
            }
            set
            {
                triangleSideC = value;
            }
        }

        private double perimetr { get; set; }
        private double area { get; set; }
        public virtual double CalculatePerimetr()
        {
            perimetr = SideA + SideB + SideC;

            return perimetr;
        }
        public virtual double CalculateArea()
        {
            area = Math.Sqrt(perimetr * (perimetr - SideA) * (perimetr - SideB) * (perimetr - SideC));

            return area;
        }
        public override string ToString()
        {
            CalculatePerimetr();
            CalculateArea();

            string triangleInfo = $"Triangle has been created. \nPerimetr: {perimetr}. \nArea: {area}. " +
                                  $"\nCoordinate's: X: {X}, Y: {Y}.";

            return triangleInfo;
        }
    }
}
