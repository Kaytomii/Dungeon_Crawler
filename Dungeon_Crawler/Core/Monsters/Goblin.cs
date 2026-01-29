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
    public class Goblin : Monster
    {
        public Goblin(IItem loot)
            : base("Goblin", 25, 8, loot)
        {
        }

        public override void Attack(Entity target)
        {
            target.TakeDamage(AttackPower);
        }
    }
}
