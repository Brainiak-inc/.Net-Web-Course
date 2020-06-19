using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Circle : Figure
    {
        private double insideRadius;
        public double InsideRadius
        {
            get
            {
                return InsideRadius;
            }
            set
            {
                if (InsideRadius > 0)
                {
                    InsideRadius = value;
                }
            }
        }
        public Circle(double x, double y, double InsideRadius) : base(x, y)
        {
            insideRadius = InsideRadius;
        }

        public double insidePerimetr { get; set; }
        public virtual double getInsidePerimentr()
        {
            insidePerimetr = 2 * Math.PI * insideRadius;
            return insidePerimetr;
        }
        public override string ToString()
        {
            getInsidePerimentr();

            string circleInfo = $"Circle has been created. \nRadius: {insideRadius}. \nPerimetr: {insidePerimetr}. \nCircle's coordinates: X: {X}, Y: {Y}";

            return circleInfo;
        }

    }  
} 

