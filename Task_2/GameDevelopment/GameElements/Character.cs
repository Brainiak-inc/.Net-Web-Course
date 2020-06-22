using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Character
    {
        Skills skills;
        Direction direction;

        public string Name { get; set; }
        public abstract void Move(double speed, Direction direction);
        public abstract void Attack(Character character, double damage);
    }
}
