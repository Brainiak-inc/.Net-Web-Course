using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Tree : Board
    {
        Field field = new Field();
        double CoordinateX;
        double CoordinateY;

        public override void SetCoordinates()
        {
            CoordinateX = field.CoordinateX;
            CoordinateY = field.CoordinateY;
        }
        public override void Stop(Board board, double speed)
        {
        }
    }
}
