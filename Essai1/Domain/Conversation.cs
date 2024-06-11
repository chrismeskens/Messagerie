namespace Essai1.Domain;

/// <summary>
/// Represents a conversation with a list of messages.
/// </summary>
public class Conversation
{
    /// <summary>
    /// Gets or sets the name of the conversation.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the messages of the conversation.
    /// </summary>
    public Stack<Message> Messages { get; set; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether the conversation is selected.
    /// </summary>
    public bool Selected { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a new message in the conversation.
    /// </summary>
    public bool NewMessage { get; set; }
    
    public void CollapseConversation()
    {
        Selected = !Selected;
    }
    
    /// <summary>
    /// Retrieve the pending answer from the messages if there is one.
    /// </summary>
    /// <returns>The pending answer.</returns>
    public string? GetPendingMessage()
    {
        // string pendingAnswer = "";
        // foreach (var message in Messages)
        // {
        //     if (message.Content.Status == EMessageStatus.PendingAnswer)
        //     {
        //         pendingAnswer = message.PendingAnswer;
        //     }
        // }
        // return pendingAnswer;

        
        return Messages
            .FirstOrDefault(message => message.Content.Status == EMessageStatus.PendingAnswer)?
            .PendingAnswer;
    }
    
    public bool GetImportance()
    {
        // bool flag = false;
        // foreach (var message in Messages)
        // {
        //     if (message.Content.Importance)
        //     {
        //         flag = true;
        //     }
        // }
        // return flag;

        return Messages.Any(message => message.Content.Importance);
    }
    
    public bool GetReadStatus()
    {
        bool allMessagesRead = true;
        foreach (var message in Messages)
        {
            if(message.Content.ReadStatus == false)
            {
                allMessagesRead = false;
            }
        }
        return allMessagesRead;
    }

    public Message CreateMessage()
    {
        NewMessage = true;
        return new Message()
        {
            Sender = "UserEmail",
            MessageType = EMessageType.Writen,
            Selected = true,
        };
    }

    public Message CancelNewMessage()
    {
        NewMessage = false;
        return new Message();
    }
}