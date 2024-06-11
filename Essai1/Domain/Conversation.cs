namespace Essai1.Domain
{
    public class Conversation
    {
        public string Name { get; set; }

        public Stack<Message> Messages { get; set; } = new Stack<Message>();

        public bool Selected { get; set; }

        public bool NewMessage { get; set; }

    }
}
