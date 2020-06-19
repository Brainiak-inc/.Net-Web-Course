using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Figure
    {
        private double x, y;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value >= 0)
                {
                    x = value;
                }
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0)
                {
                    y = value;
                }
            }
        }
        protected Figure(double X, double Y)
        {
            this.x = X;
            this.y = Y;
        }
    }
}
