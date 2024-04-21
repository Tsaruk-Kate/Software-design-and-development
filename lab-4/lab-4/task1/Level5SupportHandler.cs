using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Конкретний обробник для рівня підтримки 5
    class Level5SupportHandler : SupportHandler
    {
        public override void HandleRequest(string question)
        {
            if (question.Contains("hardware"))
            {
                Console.WriteLine("Check for any loose connections and restart your computer.");
            }
            else
            {
                successor.HandleRequest(question);
            }
        }
    }
}
