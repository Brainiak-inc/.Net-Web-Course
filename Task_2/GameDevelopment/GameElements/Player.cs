using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : Character
    {
        Skills skills = new Skills();
        Direction direction = new Direction();

        public override void Attack(Character character, double damage)
        {
        }
        public override void Move(double speed, Direction direction)
        {
        }
        public void Win(Bonus bonus, double health)
        {
        }
        public void Lose(Bonus bonus, double health, Skills skills)
        {
        }
    }
}
