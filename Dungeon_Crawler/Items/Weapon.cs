using Dungeon_Crawler.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawler.Core;
namespace Dungeon_Crawler.Items;

public class Weapon : IItem
{
    public string Name { get; }
    public string Description { get; }
    public int AttackBonus { get; }

    public Weapon(string name, int attackBonus)
    {
        Name = name;
        AttackBonus = attackBonus;
        Description = $"Adds +{attackBonus} attack";
    }
}
