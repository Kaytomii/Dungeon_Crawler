using Dungeon_Crawler.Core;
using Dungeon_Crawler.Items.Interfaces;
using Dungeon_Crawler.Serialize;
using Dungeon_Crawler.Serialize.GameSerialize;
using Dungeon_Crawler.Utils;
namespace Dungeon_Crawler.Engine;

public class GameEngine
{
    public event Action<string> OnMessageLog;

    public void Battle(Hero hero, Monster monster)
    {
        while (hero.IsAlive && monster.IsAlive)
        {
            hero.Attack(monster);
            Logger.Log($"{hero.Name} attacks {monster.Name}");
            Logger.Log($"{monster.Name} HP: {monster.Health}");

            if (!monster.IsAlive)
                break;

            monster.Attack(hero);
            Logger.Log($"{monster.Name} attacks {hero.Name}");
            Logger.Log($"{hero.Name} HP: {hero.Health}");
        }

        Logger.Log("Battle ended");
        Logger.Log($"{hero.Name} HP: {hero.Health}");
        Logger.Log($"{monster.Name} HP: {monster.Health}");

    }

    public void GameMenu(Hero hero, List<Monster> monsters)
    {
        bool running = true;
        Monster currentMonster = null;

        while (running)
        {
            Logger.Log("\n MENU ");
            Logger.Log("1. Use item");
            Logger.Log("2. Select monster");
            Logger.Log("3. Start Battle with current monster");
            Logger.Log("4. Save Game");
            Logger.Log("5. Exit");
            Console.Write("Your choice: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    UseItemMenu(hero);
                    break;

                case "2":
                    if (monsters.Count == 0)
                    {
                        Logger.Log("No monsters left");
                    }
                    else
                    {
                        Logger.Log("Choose monster:");
                        for (int i = 0; i < monsters.Count; i++)
                            Logger.Log($"{i + 1}. {monsters[i].Name} (HP: {monsters[i].Health})");

                        string choice = Console.ReadLine();
                        int index = Convert.ToInt32(choice) - 1;

                        if (index >= 0 && index < monsters.Count)
                        {
                            currentMonster = monsters[index];
                            Logger.Log($"Selected {currentMonster.Name}");
                        }
                    }
                    break;

                case "3":
                    if (currentMonster == null)
                    {
                        Logger.Log("No monster selected");
                    }
                    else
                    {
                        Battle(hero, currentMonster);

                        Logger.Log($"Hero HP after battle: {hero.Health}");

                        if (!currentMonster.IsAlive)
                        {
                            Logger.Log($"{currentMonster.Name} defeated");
                            monsters.Remove(currentMonster);
                            currentMonster = null;
                        }
                    }
                    break;

                case "4":
                    SaveGame(hero, monsters);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Logger.Log("Incorrect input");
                    break;
            }

            if (!hero.IsAlive)
            {
                Logger.Log("Hero died");
                running = false;
            }

            if (monsters.Count == 0)
            {
                Logger.Log("All monsters defeated");
                running = false;
            }
        }
    }
    private void UseItemMenu(Hero hero)
    {
        if (hero.Inventory.Count == 0)
        {
            Logger.Log("Инвентарь пуст");
            return;
        }

        Logger.Log("\nВыберите предмет:");

        for (int i = 0; i < hero.Inventory.Count; i++)
        {
            Logger.Log($"{i + 1}. {hero.Inventory[i].Name}");
        }

        Console.Write("Выбор: ");
        string input = Console.ReadLine();

        int index = Convert.ToInt32(input) - 1;

        if (index >= 0 && index < hero.Inventory.Count)
            {
                if (hero.Inventory[index] is IUsable usable)
                {
                    usable.Use(hero);
                    Logger.Log($"Using {hero.Inventory[index].Name}");
                }
                else
                {
                    Logger.Log("You cant use this item ", LogType.Warning);
                }
            }
    }
    private void SaveGame(Hero hero, List<Monster> monsters)
    {
        GameState state = new GameState
        {
            Hero = hero,
            Monsters = monsters
        };

        GameStorage storage = new GameStorage("save.json");
        storage.Save(state);

        Logger.Log("Game Saved", LogType.Log);
    }

}
