using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    interface ICharacterBuilder
    {
        ICharacterBuilder SetHeight(int height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string hairColor);
        ICharacterBuilder SetEyeColor(string eyeColor);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder SetInventory(string inventory);
        ICharacterBuilder SetGood(bool isGood);
        ICharacterBuilder AddGoodDeed(string deed);
        ICharacterBuilder AddEvilDeed(string deed);
        Character Build();
    }
}
