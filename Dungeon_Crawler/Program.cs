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
        hero.Inventory.Add(new Weapon("Sword"));
        hero.Inventory.Add(new HealingPotion());

        List<Monster> monsters = new List<Monster>
        {
            new Goblin(new Armor("Leather Armor")),
            new Orc(new Weapon("Axe")),
            new Boss(new HealingPotion())
        };

        GameEngine engine = new GameEngine();

        engine.GameMenu(hero, monsters);
    }
}
