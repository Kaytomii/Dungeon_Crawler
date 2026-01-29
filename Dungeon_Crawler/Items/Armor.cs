using Dungeon_Crawler.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawler.Core;
namespace Dungeon_Crawler.Items;

public class Armor : IItem
{
    public string Name { get; }
    public string Description { get; }
    public int DamageReduction { get; }

    public Armor(string name, int damageReduction)
    {
        Name = name;
        DamageReduction = damageReduction;
        Description = $"Reduces damage by {damageReduction}";
    }

    public int ReduceDamage(int damage)
    {
        int result = damage - DamageReduction;
        return result < 0 ? 0 : result;
    }
}
