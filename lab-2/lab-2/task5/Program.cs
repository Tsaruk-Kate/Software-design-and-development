using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо героя
            ICharacterBuilder heroBuilder = new HeroBuilder("Kateryna");
            CharacterDirector heroDirector = new CharacterDirector(heroBuilder);
            Character kateryna = heroDirector.CreateCharacter();

            // Налаштовуємо героя
            kateryna = heroBuilder.SetHeight(170)
                                  .SetBuild("Athletic")
                                  .SetHairColor("Brown")
                                  .SetEyeColor("Brown")
                                  .SetClothing("Armor")
                                  .SetInventory("Лук і стріли")
                                  .SetGood(true)
                                  .AddGoodDeed("Rescued a village from bandits")
                                  .AddGoodDeed("Helped heal the sick")
                                  .Build();

            // Створюємо ворога
            ICharacterBuilder enemyBuilder = new EnemyBuilder("The Dark Lord");
            CharacterDirector enemyDirector = new CharacterDirector(enemyBuilder);
            Character darkLord = enemyDirector.CreateCharacter();

            // Налаштовуємо ворога
            darkLord = enemyBuilder.SetHeight(190)
                                   .SetBuild("Skinny")
                                   .SetHairColor("Black")
                                   .SetEyeColor("Black")
                                   .SetClothing("Mantle")
                                   .SetInventory("The magic wand")
                                   .SetGood(false)
                                   .AddEvilDeed("Destroyed a peaceful village")
                                   .AddEvilDeed("Enslaved an entire population")
                                   .Build();

            // Виводимо деталі створених персонажів
            Console.WriteLine("----- Hero Details -----");
            kateryna.ShowDetails();
            Console.WriteLine("\n----- Enemy Details -----");
            darkLord.ShowDetails();
        }
    }
}
