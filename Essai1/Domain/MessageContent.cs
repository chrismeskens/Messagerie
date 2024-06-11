namespace Essai1.Domain;

public class MessageContent
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public string Notification { get; set; }
    public EMessageStatus Status { get; set; }
    public bool Importance { get; set; }
    public bool ReadStatus { get; set; }
}