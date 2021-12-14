using Dependencies;

namespace StructuralPattern.Decorator.Notifications;

public class EmailNotification : Notification
{
    private readonly ISendEmails _sendEmails;

    public EmailNotification(Notifier notifier, ISendEmails sendEmails) : base(notifier)
    {
        _sendEmails = sendEmails;
    }

    public override async Task HandleTableReadyMessage()
    {
        await base.HandleTableReadyMessage();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(":: Email - Preparing an email");
        Console.ResetColor();

        EmailMessage email = new("customer@example.com", "Your table is ready!");

        await _sendEmails.SendMessage(email);
    }
}