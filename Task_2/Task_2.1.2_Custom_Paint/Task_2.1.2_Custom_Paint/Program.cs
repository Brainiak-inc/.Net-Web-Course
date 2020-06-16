using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;

namespace Task_2._1._2_Custom_Paint
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Dot
    {
        private int x, y;

        void getCoordinates(int x, int y)
        {

        }
        public Dot()
        {
            Console.Write($"Enter coordinate x: {x}");
            x = int.Parse(Console.ReadLine());
            Console.Write($"Enter coordinate y: {y}");
            y = int.Parse(Console.ReadLine());

        }
        protected virtual void SetDot()
        {
            Console.SetCursorPosition(x,y);
        }
    }
    public class Ring : Dot
    {
        private int radius;
        public void PrintRing()
        {
            
        }

    }
}
