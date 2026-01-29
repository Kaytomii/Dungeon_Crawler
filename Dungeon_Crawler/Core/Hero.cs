using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawler.Items;
using Dungeon_Crawler.Items.Interfaces;
namespace Dungeon_Crawler.Core
{
    public class Hero : Entity
    {
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public List<IItem> Inventory { get; }

        public Hero(string name)
            : base(name, 100, 10)
        {
            Level = 1;
            Experience = 0;
            Inventory = new List<IItem>();
        }

        public override void Attack(Entity target)
        {
            target.TakeDamage(AttackPower);
        }

        public void GainExperience(int amount)
        {
            Experience += amount;

            if (Experience >= Level * 100)
            {
                Level++;
                AttackPower += 5;
                Health += 20;
            }
        }
    }
}
