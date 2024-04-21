using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Конкретний обробник для рівня підтримки 6
    class Level6SupportHandler : SupportHandler
    {
        public override void HandleRequest(string question)
        {
            Console.WriteLine("Please contact our premium support team for further assistance (for only $500).");
        }
    }
}
