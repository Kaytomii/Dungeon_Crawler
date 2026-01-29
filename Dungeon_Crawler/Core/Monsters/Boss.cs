using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon_Crawler.Core;

namespace Dungeon_Crawler.Core.Monsters
{
    public class Boss : Monster
    {
        public Boss(object loot)
            : base("Boss", 200, 20, loot)
        {
        }

        public override void Attack(Entity target)
        {
            if (Health < 100)
            {
                target.TakeDamage(AttackPower * 2);
            }
            else
            {
                target.TakeDamage(AttackPower);
            }
        }
    }
}

