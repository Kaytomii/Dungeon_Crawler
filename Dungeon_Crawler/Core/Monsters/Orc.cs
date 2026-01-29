using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dungeon_Crawler.Core;

namespace Dungeon_Crawler.Core.Monsters
{
    public class Orc : Monster
    {
        public Orc(object loot)
            : base("Orc", 80, 15, loot)
        {
        }

        public override void Attack(Entity target)
        {
            target.TakeDamage(AttackPower);
        }
    }
}

