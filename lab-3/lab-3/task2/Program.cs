using System;
using System.Collections.Generic;
using task2;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose your hero:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Paladin");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            int heroChoice = Convert.ToInt32(Console.ReadLine());

            Hero selectedHero = null;

            switch (heroChoice)
            {
                case 1:
                    selectedHero = new Warrior();
                    break;
                case 2:
                    selectedHero = new Mage();
                    break;
                case 3:
                    selectedHero = new Paladin();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            List<InventoryDecorator> selectedInventoryItems = new List<InventoryDecorator>();

            while (true)
            {
                Console.WriteLine("Choose your inventory type (or enter 'done' to finish):");
                Console.WriteLine("1. Armor");
                Console.WriteLine("2. Weapon");
                Console.WriteLine("3. Artifact");
                Console.WriteLine("Enter 'done' to finish selecting inventory types");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                    break;

                int inventoryTypeChoice = Convert.ToInt32(input);

                string inventoryType = "";

                switch (inventoryTypeChoice)
                {
                    case 1:
                        inventoryType = "Armor";
                        break;
                    case 2:
                        inventoryType = "Weapon";
                        break;
                    case 3:
                        inventoryType = "Artifact";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                }

                List<string> availableItems = new List<string>();

                switch (inventoryType)
                {
                    case "Armor":
                        availableItems.Add("Armor Suit");
                        availableItems.Add("Swimsuit");
                        availableItems.Add("Outfit");
                        break;
                    case "Weapon":
                        availableItems.Add("Sword");
                        availableItems.Add("Dagger");
                        availableItems.Add("Gun");
                        break;
                    case "Artifact":
                        availableItems.Add("Amulet");
                        availableItems.Add("Elixir");
                        availableItems.Add("Relic");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                }

                Console.WriteLine($"Available {inventoryType}s:");
                for (int i = 0; i < availableItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableItems[i]}");
                }
                Console.Write($"Enter your {inventoryType} choice: ");
                int inventoryItemChoice = Convert.ToInt32(Console.ReadLine());

                if (inventoryItemChoice < 1 || inventoryItemChoice > availableItems.Count)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                string inventoryItem = availableItems[inventoryItemChoice - 1];
                selectedInventoryItems.Add(new InventoryDecorator(selectedHero, inventoryType, new List<string> { inventoryItem }));
            }

            foreach (InventoryDecorator inventory in selectedInventoryItems)
            {
                selectedHero = inventory;
            }

            Console.WriteLine("-----------------");
            Console.WriteLine("Selected Options:");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Hero: {selectedHero.GetDescription()}");

            foreach (InventoryDecorator inventory in selectedInventoryItems)
            {
                Console.WriteLine($"Type inventory: {inventory.GetInventoryType()}");
                Console.WriteLine("Inventory:");
                foreach (string item in inventory.inventoryItems)
                {
                    Console.WriteLine($"- {item}");
                }
            }

            Console.WriteLine("\nChoose your next action:");
            Console.WriteLine("1. Change player");
            Console.WriteLine("2. Change inventory");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int nextAction = Convert.ToInt32(Console.ReadLine());

            switch (nextAction)
            {
                case 1:
                    Console.WriteLine("Changing player...");
                    break;
                case 2:
                    Console.WriteLine("Changing inventory...");
                    break;
                case 3:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Exiting...");
                    return;
            }
        }
    }
}
