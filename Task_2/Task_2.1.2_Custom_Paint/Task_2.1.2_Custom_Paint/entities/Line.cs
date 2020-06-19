using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task_2._1._2_Custom_Paint
{
    class Line : Figure
    {
        private double length;

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value < 0)
                {
                    length = value;
                }
            }
        }

        public override string ToString()
        {
            string lineInfo = $"Line has been created. \nLine's length: {length}. \nLine's coordinates: X: {X}, Y: {Y}.";

            return lineInfo;
        }
    }
}
