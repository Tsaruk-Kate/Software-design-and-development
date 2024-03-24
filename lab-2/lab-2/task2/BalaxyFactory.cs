using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class BalaxyFactory : IGadgetFactory
    {
        public Laptop CreateLaptop()
        {
            return new BalaxyLaptop();
        }

        public Netbook CreateNetbook()
        {
            return new BalaxyNetbook();
        }

        public EBook CreateEBook()
        {
            return new BalaxyEBook();
        }

        public Smartphone CreateSmartphone()
        {
            return new BalaxySmartphone();
        }
    }
    class BalaxyLaptop : Laptop
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("BalaxyLaptop");
        }
    }

    class BalaxyNetbook : Netbook
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("BalaxyNetbook");
        }
    }

    class BalaxyEBook : EBook
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("BalaxyEBook");
        }
    }

    class BalaxySmartphone : Smartphone
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("BalaxySmartphone");
        }
    }
}
