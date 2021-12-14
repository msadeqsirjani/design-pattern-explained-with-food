using System.Text;

namespace Dependencies;

public class ConsoleLogger : IApplicationLogger
{
    public ConsoleLogger()
    {
        Console.OutputEncoding = Encoding.UTF8;
    }

    public void LogDebug(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Write(message);
    }

    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Write(message);
    }

    public void LogInfo(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Write(message);
    }

    private static void Write(string message)
    {
        Console.WriteLine(message);
        Console.ResetColor();
    }
}