using Essai1.Domain;
using Essai1.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Essai1.Pages;

public partial class Collapsing
{
    private List<Conversation> Conversations { get; set; } = [];

    private bool CreateNewMessage { get; set; }

    private Message NewMessage { get; set; } = new();

    protected override void OnInitialized()
    {
        Conversations = DummyConversations.GetConversations();
    }

    private string SwitchMessageBackGround(Message message)
    {
        if (message.Selected)
        {
            return "#E8F5E9";
        }

        if (message.Selected == false && message.Content.ReadStatus == false)
        {
            return "#E8F5E9;border-width:thick;";
        }

        return "#FFFFFF";
    }


    private string SwitchConversationBackGround(bool selected)
    {
        return selected
            ? "#E8F5E9"
            : "#FFFFFF";
    }



    private bool GetImportance(Conversation conversation)
    {
        bool flag = false;
        foreach (var message in conversation.Messages)
        {
            if (message.Content.Importance == true)
            {
                flag = true;
            }
        }
        return flag;
    }


    private bool GetReadStatus(Conversation conversation)
    {
        bool allMessagesRead = true;
        foreach (var message in conversation.Messages)
        {
            if(message.Content.ReadStatus == false)
            {
                allMessagesRead = false;
            }
        }
        return allMessagesRead;
    }

    private void CreateMessage(Conversation conversation)
    {
        conversation.NewMessage = true;
        NewMessage = new Message()
        {
            Sender = "UserEmail",
            MessageType = EMessageType.Writen,
            Selected = true,
        };
            
    }

    private void CancelNewMessage(Conversation conversation)
    {
        conversation.NewMessage = false;
        NewMessage = new Message();
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
        DummyConversations.AddNewMessage(conversation, NewMessage);
        conversation.NewMessage = false;           
        Conversations = new List<Conversation>();
        Conversations = DummyConversations.GetConversations();
        NewMessage = new Message();
    }

    private void SetImportance()
    {
        NewMessage.Content.Importance = true;
            
    }

    private Color SetImportanceColor(Color color)
    {
        if (NewMessage.Content.Importance == true)
        {
            return color;
        }
        else
        {
            return Color.Default;
        }
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