using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Round : Circle
    {
        private double areaRound;
        public double AreaRound
        {
            get
            {
                return AreaRound;
            }
            set
            {
                if (AreaRound > 0)
                {
                    AreaRound = value;
                }
            }
        }
        public Round(double x, double y, double InsideRadius) : base(x, y, InsideRadius)
        {
            this.InsideRadius = InsideRadius;
        }
        public virtual double CalculateArea()
        {
            AreaRound = InsideRadius * InsideRadius * Math.PI;
            return AreaRound;
        }
        public override string ToString()
        {
            CalculateArea();
            getInsidePerimentr();

            string roundInfo = $"Round has been created. \nRadius: {InsideRadius}. \nPerimetr: {insidePerimetr}. \nRound's area: {AreaRound} " +
                $"\nCircle's coordinates: X: {X}, Y: {Y}";

            return roundInfo;
        }

    }
}
