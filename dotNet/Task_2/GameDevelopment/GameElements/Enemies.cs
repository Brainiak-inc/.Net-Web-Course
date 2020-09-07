using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Enemies : Character
    {
        public abstract override void Attack(Character character, double damage);

        public abstract override void Move(double speed, Direction direction);
    }
}
