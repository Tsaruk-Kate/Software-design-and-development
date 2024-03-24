using System;
using System.IO;

public class Authenticator
{
    private static Authenticator instance;
    private static readonly object lockObject = new object();
    private readonly string authenticationFilePath = "authentication.txt";

    private Authenticator() { }

    public static Authenticator Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Authenticator();
                    }
                }
            }
            return instance;
        }
    }

    public bool Authenticate(string username, string password)
    {
        if (!File.Exists(authenticationFilePath))
        {
            Console.WriteLine("Authentication file does not exist.");
            return false;
        }

        try
        {
            string[] lines = File.ReadAllLines(authenticationFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && parts[0].Trim() == username && parts[1].Trim() == password)
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading authentication file: {ex.Message}");
        }

        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the authentication system!");
        Console.WriteLine("Please enter your credentials:");

        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Authenticator authenticator = Authenticator.Instance;

        if (authenticator.Authenticate(username, password))
        {
            Console.WriteLine("Authentication successful!");
        }
        else
        {
            Console.WriteLine("Authentication failed. Invalid username or password.");
        }
    }
}
