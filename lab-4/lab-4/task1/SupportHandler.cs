using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Базовий клас для обробників запитів
    abstract class SupportHandler
    {
        // Посилання на наступний обробник у ланцюжку
        protected SupportHandler successor;

        // Метод для встановлення наступного обробника
        public void SetSuccessor(SupportHandler successor)
        {
            this.successor = successor;
        }

        // Абстрактний метод обробки запиту, який буде перевизначений у конкретних обробниках
        public abstract void HandleRequest(string question);
    }
}
