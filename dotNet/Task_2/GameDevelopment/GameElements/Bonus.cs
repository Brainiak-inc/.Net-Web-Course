using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Bonus : IUpable
    {
        Field field;
        double CoordinateX;
        double CoordinateY;

        public abstract void SetCoordinate();
        public abstract void SkillsUp(Skills skills);
    }
}
