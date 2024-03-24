using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    // Клас-директор для створення персонажів
    class CharacterDirector
    {
        private readonly ICharacterBuilder _builder;

        public CharacterDirector(ICharacterBuilder builder)
        {
            _builder = builder;
        }

        public Character CreateCharacter()
        {
            return _builder.Build();
        }
    }
}
