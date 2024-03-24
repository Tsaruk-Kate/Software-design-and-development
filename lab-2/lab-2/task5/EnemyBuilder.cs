using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    // Будівельник для створення ворога
    class EnemyBuilder : ICharacterBuilder
    {
        private Character character;

        public EnemyBuilder(string name)
        {
            character = new Character();
            character.Name = name;
            character.GoodDeeds = new List<string>();
            character.EvilDeeds = new List<string>();
        }

        public ICharacterBuilder SetHeight(int height)
        {
            character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothing(string clothing)
        {
            character.Clothing = clothing;
            return this;
        }

        public ICharacterBuilder SetInventory(string inventory)
        {
            character.Inventory = inventory;
            return this;
        }

        public ICharacterBuilder SetGood(bool isGood)
        {
            // Для ворога параметр isGood буде обернутий
            // Ворог завжди не є "добрим"
            character.IsGood = !isGood;
            return this;
        }

        public ICharacterBuilder AddGoodDeed(string deed)
        {
            // Не можна додавати добрі дії для ворога
            throw new InvalidOperationException("Cannot add good deeds for an enemy.");
        }

        public ICharacterBuilder AddEvilDeed(string deed)
        {
            character.EvilDeeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return character;
        }
    }
}
