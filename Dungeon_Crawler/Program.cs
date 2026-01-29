using Dungeon_Crawler.Core;
using Dungeon_Crawler.Core.Monsters;
using Dungeon_Crawler.Engine;
using Dungeon_Crawler.Items;
using Dungeon_Crawler.Items.Interfaces;
using Dungeon_Crawler.Utils;
using Microsoft.Extensions.Logging;

namespace Dungeon_Crawler;

internal class Program
{
    static void Main(string[] args)
    {
        Hero hero = new Hero("Test");
        hero.Inventory.Add(new Weapon("Sword", 5));
        hero.Inventory.Add(new HealingPotion());
        List<Monster> monsters = new List<Monster>
        {
            new Goblin(new Armor("Leather Armor", 2)),
            new Orc(new Weapon("Axe", 7)),
            new Boss(new HealingPotion())
        };

        GameEngine engine = new GameEngine();

        engine.OnMessageLog += message => Logger.Log(message, LogType.Log);

        engine.GameMenu(hero, monsters);
    }
}
