using System;
using task2;

abstract class Laptop
{
    public abstract void DisplayInfo();
}

abstract class Netbook
{
    public abstract void DisplayInfo();
}

abstract class EBook
{
    public abstract void DisplayInfo();
}

abstract class Smartphone
{
    public abstract void DisplayInfo();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a brand:");
        Console.WriteLine("1. IProne");
        Console.WriteLine("2. Kiaomi");
        Console.WriteLine("3. Balaxy");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        IGadgetFactory factory = null;

        switch (choice)
        {
            case "1":
                factory = new IProneFactory();
                break;
            case "2":
                factory = new KiaomiFactory();
                break;
            case "3":
                factory = new BalaxyFactory();
                break;
            case "4":
                Console.WriteLine("Exiting the program...");
                return;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }

        if (factory != null)
        {
            Laptop laptop = factory.CreateLaptop();
            Netbook netbook = factory.CreateNetbook();
            EBook eBook = factory.CreateEBook();
            Smartphone smartphone = factory.CreateSmartphone();

            Console.WriteLine($"Using {choice} factory:");
            laptop.DisplayInfo();
            netbook.DisplayInfo();
            eBook.DisplayInfo();
            smartphone.DisplayInfo();
        }
    }
}