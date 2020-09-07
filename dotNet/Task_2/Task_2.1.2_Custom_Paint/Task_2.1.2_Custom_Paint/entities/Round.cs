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
                return areaRound;
            }
            set
            {
                if (value > 0)
                {
                    areaRound = value;
                }
            }
        }

        public virtual double CalculateArea()
        {
            AreaRound = InsideRadius * InsideRadius * Math.PI;
            return AreaRound;
        }
        public override string ToString()
        {
            CalculateArea();
            GetInsidePerimentr();

            string roundInfo = $"Round has been created. \nRadius: {InsideRadius}. \nPerimetr: {insidePerimetr}. \nRound's area: {AreaRound} " +
                $"\nCircle's coordinates: X: {X}, Y: {Y}";

            return roundInfo;
        }

    }
}
