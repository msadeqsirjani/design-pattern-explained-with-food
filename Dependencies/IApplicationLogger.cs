namespace Dependencies;

public interface IApplicationLogger
{
    void LogInfo(string message, ConsoleColor color = ConsoleColor.White);
    void LogDebug(string message);
    void LogError(string message);
}