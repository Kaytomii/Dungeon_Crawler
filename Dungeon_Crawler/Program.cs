using Dungeon_Crawler.Core;
using Dungeon_Crawler.Core.Monsters;
using Dungeon_Crawler.Engine;
using Dungeon_Crawler.Items;
using Dungeon_Crawler.Serialize;
using Dungeon_Crawler.Items.Interfaces;
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
        engine.OnMessageLog += Console.WriteLine;

        engine.GameMenu(hero, monsters);
    }
}
