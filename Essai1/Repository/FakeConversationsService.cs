using Bogus;
using Essai1.Domain;

namespace Essai1.Repository;

public class FakeConversationsService : IConversationsService
{
    private readonly List<Conversation> _conversations;

    public FakeConversationsService()
    {
        // Get 100 conversations using Bogus
        _conversations = new Faker<Conversation>()
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .Generate(100);

        // Get 1000 messages using Bogus
        var messages = new Faker<Message>()
            .RuleFor(m => m.Sender, f => f.Name.FullName())
            .RuleFor(m => m.Receiver, f => f.Name.FullName())
            .RuleFor(m => m.ReceptionDate, f => f.Date.Future().ToString())
            .RuleFor(m => m.MessageType, f => f.PickRandom<EMessageType>())
            .RuleFor(m => m.PendingAnswer, f => f.Lorem.Sentence())
            .RuleFor(m => m.Content, f => new MessageContent
            {
                Subject = f.Lorem.Sentence(),
                Body = f.Lorem.Paragraph(),
                Notification = f.Lorem.Sentence(),
                Status = f.PickRandom<EMessageStatus>()
            })
            .Generate(1000);
        
        // Distribute messages to conversations equally
        var conversationsCount = _conversations.Count;
        var messagesCount = messages.Count;
        var messagesPerConversation = messagesCount / conversationsCount;
        for (var i = 0; i < conversationsCount; i++)
        {
            var conversation = _conversations[i];
            conversation.Messages = new Stack<Message>();
            for (var j = 0; j < messagesPerConversation; j++)
            {
                conversation.Messages.Push(messages[i * messagesPerConversation + j]);
            }
        }
    }
    
    public List<Conversation> GetConversations()
    {
        return _conversations;
    }

    public void AddNewMessage(Conversation conversation, Message message)
    {
        conversation.Messages.Push(message);
    }
}