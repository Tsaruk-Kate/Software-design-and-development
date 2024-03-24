using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    interface IGadgetFactory
    {
        Laptop CreateLaptop();
        Netbook CreateNetbook();
        EBook CreateEBook();
        Smartphone CreateSmartphone();
    }
}
