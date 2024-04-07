using task1;

// Клас FileLoggerAdapter використовується для адаптації інтерфейсу ILogger до класу FileWriter
public class FileLoggerAdapter : ILogger
{
    private readonly FileWriter fileWriter;

    public FileLoggerAdapter(string filePath)
    {
        this.fileWriter = new FileWriter(filePath);
    }

    public void Log(string message)
    {
        fileWriter.WriteLine($"LOG: {message}");
    }

    public void Error(string message)
    {
        fileWriter.WriteLine($"ERROR: {message}");
    }

    public void Warn(string message)
    {
        fileWriter.WriteLine($"WARNING: {message}");
    }
}
