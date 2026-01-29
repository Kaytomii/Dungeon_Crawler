using Dungeon_Crawler.Core;
using Dungeon_Crawler.Items.Interfaces;
using Dungeon_Crawler.Serialize;
using Dungeon_Crawler.Serialize.GameSerialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Dungeon_Crawler.Engine;

public class GameEngine
{
    public event Action<string> OnMessageLog;

    public void Battle(Hero hero, Monster monster)
    {
        while (hero.IsAlive && monster.IsAlive)
        {
            hero.Attack(monster);
            Console.WriteLine($"{hero.Name} attacks {monster.Name}");
            Console.WriteLine($"{monster.Name} HP: {monster.Health}");

            if (!monster.IsAlive)
                break;

            monster.Attack(hero);
            Console.WriteLine($"{monster.Name} attacks {hero.Name}");
            Console.WriteLine($"{hero.Name} HP: {hero.Health}");
        }

        Console.WriteLine("Battle ended");
        Console.WriteLine($"{hero.Name} HP: {hero.Health}");
        Console.WriteLine($"{monster.Name} HP: {monster.Health}");

    }

    public void GameMenu(Hero hero, List<Monster> monsters)
    {
        bool running = true;
        Monster currentMonster = null;

        while (running)
        {
            Console.WriteLine("\n MENU ");
            Console.WriteLine("1. Use item");
            Console.WriteLine("2. Select monster");
            Console.WriteLine("3. Start Battle with current monster");
            Console.WriteLine("4. Save Game");
            Console.WriteLine("5. Exit");
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
                        Console.WriteLine("No monsters left");
                    }
                    else
                    {
                        Console.WriteLine("Choose monster:");
                        for (int i = 0; i < monsters.Count; i++)
                            Console.WriteLine($"{i + 1}. {monsters[i].Name} (HP: {monsters[i].Health})");

                        string choice = Console.ReadLine();
                        int index = Convert.ToInt32(choice) - 1;

                        if (index >= 0 && index < monsters.Count)
                        {
                            currentMonster = monsters[index];
                            Console.WriteLine($"Selected {currentMonster.Name}");
                        }
                    }
                    break;

                case "3":
                    if (currentMonster == null)
                    {
                        Console.WriteLine("No monster selected");
                    }
                    else
                    {
                        Battle(hero, currentMonster);

                        Console.WriteLine($"Hero HP after battle: {hero.Health}");

                        if (!currentMonster.IsAlive)
                        {
                            Console.WriteLine($"{currentMonster.Name} defeated");
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
                    Console.WriteLine("Incorrect input");
                    break;
            }

            if (!hero.IsAlive)
            {
                Console.WriteLine("Hero died");
                running = false;
            }

            if (monsters.Count == 0)
            {
                Console.WriteLine("All monsters defeated");
                running = false;
            }
        }
    }
    private void UseItemMenu(Hero hero)
    {
        if (hero.Inventory.Count == 0)
        {
            Console.WriteLine("Инвентарь пуст");
            return;
        }

        Console.WriteLine("\nВыберите предмет:");

        for (int i = 0; i < hero.Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {hero.Inventory[i].Name}");
        }

        Console.Write("Выбор: ");
        string input = Console.ReadLine();

        int index = Convert.ToInt32(input) - 1;

        if (index >= 0 && index < hero.Inventory.Count)
            {
                if (hero.Inventory[index] is IUsable usable)
                {
                    usable.Use(hero);
                    Console.WriteLine($"Using {hero.Inventory[index].Name}");
                }
                else
                {
                    Console.WriteLine("You cant use this item ");
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

        Console.WriteLine("Game Saved");
    }

}
