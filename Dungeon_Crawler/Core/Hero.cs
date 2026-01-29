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
        public Weapon EquippedWeapon { get; private set; }
        public Armor EquippedArmor { get; private set; }

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

            while (Experience >= Level * 100)
            {
                Experience -= Level * 100;
                Level++;
                AttackPower += 5;
                Health += 20;

                Console.WriteLine($"{Name} leveled up Now level {Level}");
            }

        }

        public string UseItem(IItem item)
        {
            switch (item)
            {
                case HealingPotion potion:
                    potion.Use(this);
                    Inventory.Remove(item);
                    return $"Used {item.Name}";

                case Weapon weapon:
                    if (EquippedWeapon == weapon)
                        return $"{weapon.Name} is already equipped";
                    EquippedWeapon = weapon;
                    return $"Equipped weapon: {weapon.Name}";

                case Armor armor:
                    if (EquippedArmor == armor)
                        return $"{armor.Name} is already equipped";
                    EquippedArmor = armor;
                    return $"Equipped armor: {armor.Name}";

                default:
                    return "You cant use this item";
            }
        }

    }
}
