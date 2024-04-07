using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class InventoryDecorator : HeroDecorator
    {
        public List<string> inventoryItems;
        private string inventoryType;

        public InventoryDecorator(Hero hero, string inventoryType, List<string> inventoryItems) : base(hero)
        {
            this.inventoryItems = inventoryItems;
            this.inventoryType = inventoryType;
        }

        public override string GetDescription()
        {
            string items = string.Join(", ", inventoryItems);
            return base.GetDescription() + $" with {items}";
        }

        public string GetInventoryType()
        {
            return inventoryType;
        }
    }
}
