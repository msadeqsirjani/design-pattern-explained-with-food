namespace StructuralPattern.Decorator;

public class Notification : Notifier
{
    protected Notifier Notifier { get; }

    protected Notification(Notifier notifier)
    {
        Notifier = notifier;
    }

    public override Task HandleTableReadyMessage() => Notifier.HandleTableReadyMessage();
}