using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler.Core
{
    public abstract class Monster : Entity
    {
        public object Loot { get; protected set; }

        protected Monster(string name, int health, int attackPower, object loot)
            : base(name, health, attackPower)
        {
            Loot = loot;
        }

        public override void Attack(Entity target)
        {
            target.TakeDamage(AttackPower);
        }
    }
}
