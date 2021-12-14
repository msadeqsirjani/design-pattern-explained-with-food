namespace Dependencies;

public class EmailMessage
{
    public string To { get; set; }
    public string Content { get; set; }
    public EmailMessage(string to, string content)
    {
        To = to;
        Content = content;
    }
}