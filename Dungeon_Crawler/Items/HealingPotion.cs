using Dungeon_Crawler.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawler.Core;
namespace Dungeon_Crawler.Items;

public class HealingPotion : IItem, IUsable
{
    public string Name => "Healing Potion";
    public string Description => "Restores 30 HP";

    public void Use(Hero hero)
    {
        hero.TakeDamage(-30);
    }
}