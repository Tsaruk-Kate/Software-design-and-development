using task1;

class Program
{
    static void Main(string[] args)
    {
        // Створюються екземпляри обробників для кожного рівня підтримки
        SupportHandler level1 = new Level1SupportHandler();
        SupportHandler level2 = new Level2SupportHandler();
        SupportHandler level3 = new Level3SupportHandler();
        SupportHandler level4 = new Level4SupportHandler();
        SupportHandler level5 = new Level5SupportHandler();
        SupportHandler level6 = new Level6SupportHandler();

        // Встановлюється зв'язок між обробниками у ланцюжку
        level1.SetSuccessor(level2);
        level2.SetSuccessor(level3);
        level3.SetSuccessor(level4);
        level4.SetSuccessor(level5);
        level5.SetSuccessor(level6);

        // Масив запитів для взаємодії з користувачем
        string[] questions = {
            "Are you experiencing issues with displaying channels on the TV? (y/n)",
            "Are you experiencing issues with the internet? (y/n)",
            "Are you experiencing issues with your router? (y/n)",
            "Are you experiencing software-related issues? (y/n)",
            "Are you experiencing hardware-related issues? (y/n)",
            "Is there any other issue you need assistance with? (y/n)"
        };

        bool noValidResponse = true;

        // Поки користувач не вибрав відповідь, цикл буде продовжуватися
        while (noValidResponse)
        {
            foreach (string question in questions)
            {
                Console.WriteLine(question);
                string answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    // Якщо користувач відповів "y", обробляємо запит на першому рівні підтримки
                    level1.HandleRequest(question);
                    noValidResponse = false;
                    break;
                }
                else if (answer.ToLower() == "n")
                {
                    // Якщо користувач відповів "n", переходимо до наступного запиту
                    continue;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n'.");
                }
            }
        }
    }
}