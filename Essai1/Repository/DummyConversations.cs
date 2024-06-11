using Essai1.Domain;

namespace Essai1.Repository
{
    public class DummyConversations
    {
        public static List<Conversation> Conversations { get; set; } = new List<Conversation>()
        {
            new Conversation()
            {
                Name = "Conversation 1",
                Messages = new Stack<Message>()
            },
            new Conversation()
            {
                Name = "Conversation 2",
                Messages = new Stack<Message>()
            }
        };

        public static List<Message> Messages1  { get; set; } = new List<Message>()
        {
            new Message()
            {
                Sender = "sender one",
                Receiver = "receiver one",
                ReceptionDate = "03/06/2024",
                MessageType = EMessageType.Spoken,
                Content = new MessageContent
                {
                    Subject = "Rappel one",
                    Body = "Some text...",
                    Notification = "Some notification",
                    Status = EMessageStatus.Active,
                }
            },
            new Message()
            {
                Sender = "sender two",
                Receiver = "receiver one",
                ReceptionDate = "05/06/2024",
                MessageType = EMessageType.Spoken,
                PendingAnswer = "Réponse pour le 15/06/2024",
                Content = new MessageContent
                {
                    Subject = "Rappel one",
                    Body = "Some text...",
                    Notification = "Some notification",
                    Status = EMessageStatus.PendingAnswer,
                }
            }
        };

        public static List<Message> Messages2 { get; set; } = new List<Message>()
        {
            new Message()
            {
                Sender = "sender three",
                Receiver = "receiver three",
                ReceptionDate = "07/06/2024",
                MessageType = EMessageType.Writen,
                Content = new MessageContent
                {
                    Subject = "Rappel Two",
                    Body = "Some text...",
                    Notification = "Some notification",
                    Status = EMessageStatus.Active,
                }
            },
            new Message()
            {
                Sender = "sender four",
                Receiver = "receiver four",
                ReceptionDate = "09/06/2024",
                MessageType = EMessageType.Writen,
                PendingAnswer = "",
                Content = new MessageContent
                {
                    Subject = "Rappel Two",
                    Body = "Some text...",
                    Notification = "Some notification",
                    Status = EMessageStatus.Active,
                }
            }
        };


        public static List<Conversation> GetConversations()
        {
            foreach (var conversation in Conversations)
            {
                conversation.Messages = new Stack<Message>();
            }
            foreach(var message in Messages1 )
            {
                Conversations[0].Messages.Push( message );
            }

            foreach (var message in Messages2)
            {
                Conversations[1].Messages.Push(message);
            }

            return Conversations;
        }

        public static void AddNewMessage(Conversation conversation,Message message)
        {
            if (conversation.Name == "Conversation 1")
            {
                Messages1.Add( message );
            }
            else
            {
                Messages2.Add( message );
            }
        }

    }
}
