using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Pills : Bonus
    {
        Field field = new Field();
        double CoordinateX;
        double CoordinateY;

        public override void SetCoordinate()
        {
            CoordinateX = field.CoordinateX;
            CoordinateY = field.CoordinateY;
        }
        public override void SkillsUp(Skills skills)
        {
        }

    }
}
