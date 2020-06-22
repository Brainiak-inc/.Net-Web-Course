using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Infected : Enemies
    {
        public abstract void SpecialAttack(Character character, double damage);

        public abstract void SpecialMove(double speed, Direction direction);
    }
}
