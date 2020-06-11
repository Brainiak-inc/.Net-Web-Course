using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Ring
    {
        protected double radius;
        protected double x;
        protected double y;
        public Ring(double Radius, double X, double Y)//Constrctor with 3 params
        {
            x = X;
            y = Y;
            radius = Radius;
        }
        public Ring(double Radius)
        {
            x = 0;
            y = 0;
            radius = Radius;
        }
        public void DisplayRing()
        {

        }
    }
}
