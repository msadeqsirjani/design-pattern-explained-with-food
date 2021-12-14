namespace Dependencies;

public interface ISendEmails
{
    Task SendMessage(EmailMessage message);
}