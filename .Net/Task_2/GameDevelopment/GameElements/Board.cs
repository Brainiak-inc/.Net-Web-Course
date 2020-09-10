using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Board : IStoppable
    {
        Field field;
        double CoordinateX;
        double CoordinateY;

        public abstract void SetCoordinates();

        public abstract void Stop(Board board, double speed);
    }
}
