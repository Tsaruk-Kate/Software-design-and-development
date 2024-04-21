using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Конкретний обробник для рівня підтримки 4
    class Level4SupportHandler : SupportHandler
    {
        public override void HandleRequest(string question)
        {
            if (question.Contains("software"))
            {
                Console.WriteLine("Try reinstalling the software.");
            }
            else
            {
                successor.HandleRequest(question);
            }
        }
    }
}
