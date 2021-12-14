namespace Dependencies;

public class Queue : IQueue
{
    private readonly IApplicationLogger _logger;

    public Queue(IApplicationLogger logger)
    {
        _logger = logger;  
    }

    public void Add(QueueMessage item)
    {
        Thread.Sleep(250);
        _logger.LogInfo($"Added to queue: {item.Content}", ConsoleColor.Magenta);
    }
}