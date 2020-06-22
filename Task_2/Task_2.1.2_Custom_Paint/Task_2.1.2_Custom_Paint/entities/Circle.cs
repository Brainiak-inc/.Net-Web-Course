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
                return insideRadius;
            }
            set
            {
                if (value > 0)
                {
                    insideRadius = value;
                }
            }
        }

        public double insidePerimetr { get; set; }
        public virtual double GetInsidePerimentr()
        {
            insidePerimetr = 2 * Math.PI * insideRadius;
            return insidePerimetr;
        }
        public override string ToString()
        {
            GetInsidePerimentr();

            string circleInfo = $"Circle has been created. \nRadius: {insideRadius}. \nPerimetr: {insidePerimetr}. \nCircle's coordinates: X: {X}, Y: {Y}";

            return circleInfo;
        }

    }  
} 

