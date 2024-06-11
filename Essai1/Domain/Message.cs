using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Primitives;

namespace Essai1.Domain
{
    public class Message
    {
        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string Notification { get; set; }

        public bool Importance { get; set; }

        public bool Selected { get; set; } = false;

        public string Color { get; set; } = "#FFFFFF";

        public string CreationDate { get; set; } = "Concept";

        public string ReceptionDate { get; set; }

        public string SendingDate { get; set; }

        public EMessageType MessageType { get; set; }

        public EMessageStatus Status { get; set; }

        public string PendingAnswer { get; set; }

        public bool Pending {  get; set; } = false;

        public DateTime? PendingDate {  get; set; }

        public IBrowserFile NewFile { get; set; }

        public IList<IBrowserFile> Files { get; set; }

        public bool ReadStatus { get; set; }

    }

}
