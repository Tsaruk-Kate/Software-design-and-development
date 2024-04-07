using System;

// Клас FileWriter забезпечує можливість записувати повідомлення у файл
public class FileWriter
{
    private readonly string filePath;

    public FileWriter(string filePath)
    {
        this.filePath = filePath;
    }

    public void Write(string message)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
        {
            writer.Write(message);
        }
    }

    public void WriteLine(string message)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
        {
            writer.WriteLine(message);
        }
    }
}
