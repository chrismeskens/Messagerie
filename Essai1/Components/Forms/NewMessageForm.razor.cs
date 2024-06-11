using Essai1.Domain;
using Essai1.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Essai1.Components.Forms;

public partial class NewMessageForm
{
    [Inject]
    public required IConversationsService ConversationsService { get; set; }
    
    [Parameter, EditorRequired]
    public required Conversation Conversation { get; set; }
    
    [Parameter, EditorRequired]
    public required Message NewMessage { get; set; }
    
    private void CancelNewMessage(Conversation conversation)
    {
        NewMessage = conversation.CancelNewMessage();
    }

    private void UploadFile()
    {
        NewMessage.Attachments.Files = new List<IBrowserFile>();
        NewMessage.Attachments.Files.Add(NewMessage.Attachments.NewFile);
    }

    private void AddNewMessage(Conversation conversation)
    {
        var now = DateTime.Now.ToString("dd/MM/yyyy");
        NewMessage.CreationDate = now;
        NewMessage.ReceptionDate = now;
        NewMessage.SendingDate = now;
        ConversationsService.AddNewMessage(conversation, NewMessage);
        conversation.NewMessage = false;         
        // TODO: Check if the following line is really neaded
        // Conversations = new List<Conversation>();
        // Conversations = ConversationsService.GetConversations();
        NewMessage = new Message();
    }

    private void SetImportance()
    {
        NewMessage.Content.Importance = true;
            
    }

    private Color SetImportanceColor(Color color)
    {
        return NewMessage.Content.Importance
            ? color
            : Color.Default;
    }

    private Color SetAttachmentColor(Color color)
    {
        if (NewMessage.Attachments.Files != null && NewMessage.Attachments.Files.Count>0)
        {
            return color;
        }
        else
        {
            return Color.Primary;
        }
    }

    private Color SetPendingColor(Color color)
    {
        if (!string.IsNullOrEmpty(NewMessage.PendingAnswer))
        {
            return color;
        }
        else
        {
            return Color.Default;
        }
    }

    private void SetPendingAnswer()
    {
        NewMessage.Pending = true;
    }

    private void AddPendingAnswer()
    {
        if(NewMessage.PendingDate != null)
        {
            NewMessage.PendingAnswer += NewMessage.PendingDate.ToString();
        }           
        NewMessage.Pending = false;
    }

    private void CancelPendingAnswer()
    {
        NewMessage.Pending = false;
        NewMessage.PendingAnswer = "";
    }
}