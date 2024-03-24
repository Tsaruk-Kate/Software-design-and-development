using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class IProneFactory : IGadgetFactory
    {
        public Laptop CreateLaptop()
        {
            return new IPhoneLaptop();
        }

        public Netbook CreateNetbook()
        {
            return new IPhoneNetbook();
        }

        public EBook CreateEBook()
        {
            return new IPhoneEBook();
        }

        public Smartphone CreateSmartphone()
        {
            return new IPhoneSmartphone();
        }
    }

    class IPhoneLaptop : Laptop
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("IPhoneLaptop");
        }
    }

    class IPhoneNetbook : Netbook
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("IPhoneNetbook");
        }
    }

    class IPhoneEBook : EBook
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("IPhoneEBook");
        }
    }

    class IPhoneSmartphone : Smartphone
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("IPhoneSmartphone");
        }
    }

}
