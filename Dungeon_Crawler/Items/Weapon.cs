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

    public Weapon(string name)
    {
        Name = name;
    }
}
