using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class KiaomiFactory : IGadgetFactory
    {
        public Laptop CreateLaptop()
        {
            return new KiaomiLaptop();
        }

        public Netbook CreateNetbook()
        {
            return new KiaomiNetbook();
        }

        public EBook CreateEBook()
        {
            return new KiaomiEBook();
        }

        public Smartphone CreateSmartphone()
        {
            return new KiaomiSmartphone();
        }
    }
    class KiaomiLaptop : Laptop
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("KiaomiLaptop");
        }
    }

    class KiaomiNetbook : Netbook
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("KiaomiNetbook");
        }
    }

    class KiaomiEBook : EBook
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("KiaomiEBook");
        }
    }

    class KiaomiSmartphone : Smartphone
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("KiaomiSmartphone");
        }
    }
}
