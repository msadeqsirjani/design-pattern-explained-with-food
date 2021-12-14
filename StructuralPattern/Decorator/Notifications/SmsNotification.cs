using Dependencies;
using Newtonsoft.Json;

namespace StructuralPattern.Decorator.Notifications;

public class SmsNotification : Notification
{
    private readonly IQueue _queue;

    public SmsNotification(Notifier notifier, IQueue queue) : base(notifier)
    {
        _queue = queue;
    }

    public override Task HandleTableReadyMessage()
    {
        Task.FromResult(base.HandleTableReadyMessage());
            
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(":: SMS - Queueing up a text message");
        Console.ResetColor();

        var message = new { customerName = "Sandi", message = "Your table is ready!" };
        var jsonMessage = JsonConvert.SerializeObject(message);
        QueueMessage queueMessage = new(jsonMessage);

        _queue.Add(queueMessage);

        return Task.CompletedTask;
    }
}