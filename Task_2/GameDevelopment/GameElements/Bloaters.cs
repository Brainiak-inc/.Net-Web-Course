using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bloaters : Infected
    {
        Skills skills = new Skills();
        Direction direction = new Direction();

        public override void Attack(Character character, double damage)
        {
        }
        public override void Move(double speed, Direction direction)
        {
        }
        public override void SpecialAttack(Character character, double damage)
        {
        }
        public override void SpecialMove(double speed, Direction direction)
        {
        }
    }
}
