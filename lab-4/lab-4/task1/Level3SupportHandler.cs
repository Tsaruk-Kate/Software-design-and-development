using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Конкретний обробник для рівня підтримки 3
    class Level3SupportHandler : SupportHandler
    {
        public override void HandleRequest(string question)
        {
            if (question.Contains("router"))
            {
                Console.WriteLine("Contact your internet service provider for technical support.");
            }
            else
            {
                successor.HandleRequest(question);
            }
        }
    }
}
