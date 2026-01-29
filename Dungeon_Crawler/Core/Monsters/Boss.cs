using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawler.Items;
using Dungeon_Crawler.Core;
using Dungeon_Crawler.Items.Interfaces;

namespace Dungeon_Crawler.Core.Monsters
{
    public class Boss : Monster
    {
        public Boss(IItem loot)
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

