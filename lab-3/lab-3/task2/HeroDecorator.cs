using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public abstract class HeroDecorator : Hero
    {
        protected Hero hero;

        public HeroDecorator(Hero hero)
        {
            this.hero = hero;
        }

        public override string GetDescription()
        {
            return hero.GetDescription();
        }
    }
}
