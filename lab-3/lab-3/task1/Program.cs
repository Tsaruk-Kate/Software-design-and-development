using System;

class Program
{
    static void Main(string[] args)
    {
        var logger = new Logger();
        
        logger.Log("This is a log message");
        logger.Error("This is an error message");
        logger.Warn("This is a warning message");

        var fileLogger = new FileLoggerAdapter("file.txt");

        fileLogger.Log("This is a log message");
        fileLogger.Error("This is an error message");
        fileLogger.Warn("This is a warning message");
    }
}
