using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Конкретний обробник для рівня підтримки 2
    class Level2SupportHandler : SupportHandler
    {
        public override void HandleRequest(string question)
        {
            if (question.Contains("internet"))
            {
                Console.WriteLine("Restart the router and check the internet connection.");
            }
            else
            {
                successor.HandleRequest(question);
            }
        }
    }
}
