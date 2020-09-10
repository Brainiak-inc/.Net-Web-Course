using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Bear : Enemies
    {
        Skills skills = new Skills();
        Direction direction = new Direction();

        public override void Attack(Character character, double damage)
        {
        }

        public override void Move(double speed, Direction direction)
        {
        }

    }
}
