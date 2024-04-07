using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using task4;

public class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();
        client.Run();
    }
}

public class Client
{
    public void Run()
    {
        ITextReader reader = new SmartTextChecker();
        char[,] content = reader.ReadText("example.txt");

        if (content != null)
        {
            Console.WriteLine("File content:");
            PrintMatrix(content);
        }

        ITextReader lockedReader = new SmartTextReaderLocker("locked.*");
        lockedReader.ReadText("locked_files.txt");
    }

    private void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
