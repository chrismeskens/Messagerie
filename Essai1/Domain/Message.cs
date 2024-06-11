using System.Drawing;

namespace Essai1.Domain;

public class Message
{
    public string Sender { get; set; }

    public string Receiver { get; set; }
    
    public EMessageType MessageType { get; set; }
    
    public MessageContent Content { get; set; } = new();

    public bool Selected { get; set; }

    public string CreationDate { get; set; } = "Concept";

    public string? ReceptionDate { get; set; }

    // TODO: Use DateTime instead of string for ReceptionDate
    // public string ReceptionDateFormatted
    //     => ReceptionDate.ToString("dd/MM/yyyy");

    public string? SendingDate { get; set; }

    public string? PendingAnswer { get; set; }

    public bool Pending {  get; set; }

    public DateTime? PendingDate {  get; set; }

    public FileAttachments Attachments { get; set; } = new();

    public void CollapseMessage()
    {
        Selected = !Selected;
        Content.ReadStatus = true;
    }
    
    public string SwitchMessageBackGround()
    {
        if (Selected)
        {
            return "#E8F5E9";
        }

        if (Selected == false && Content.ReadStatus == false)
        {
            return "#E8F5E9; border-width:thick;";
        }

        return "#FFFFFF";
    }
}