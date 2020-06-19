using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Ring : Circle
    {
        private double outsideRadius;

        public double OutsideRadius
        {
            get
            {
                return outsideRadius;
            }
            set
            {
                if (outsideRadius > 0)
                {
                    outsideRadius = value;
                }
            }
        }
        public double outsidePerimetr { get; set; }
        public double RingArea { get; set; }

        //public Ring(double x, double y, double InsideRadius, double OutsideRadius) : base(x, y, InsideRadius)
        //{
        //    outsideRadius = OutsideRadius;
        //}
        public double calculateArea()
        {
            RingArea = Math.PI * (outsideRadius * outsideRadius) - (InsideRadius * InsideRadius);

            return RingArea;
        }
        public virtual double calculatePerimetr()
        {
            outsidePerimetr = 2 * Math.PI * outsideRadius;
            return outsidePerimetr;
        }
        public override string ToString()
        {
            calculateArea();
            calculatePerimetr();

            string ringInfo = $"Ring has been created. \nInside radius: {InsideRadius}. " +
                $"\nOutside radius: {outsideRadius}. \nPerimetr: {insidePerimetr}. Outside perimetr: {outsidePerimetr}" +
                $" \nCircle's coordinates: X: {X}, Y: {Y}. \nRing's area: {RingArea}";

            return ringInfo;
        }

    }
}
