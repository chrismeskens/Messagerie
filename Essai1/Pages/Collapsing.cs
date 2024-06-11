using Essai1.Domain;
using Essai1.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualBasic;
using MudBlazor;
using MudBlazor.Interfaces;
using static MudBlazor.CategoryTypes;

namespace Essai1.Pages
{
    public partial class Collapsing
    {
        private List<Conversation> Conversations { get; set; }

        private bool CreateNewMessage { get; set; }

        private Message NewMessage { get; set; }


        protected override void OnInitialized()
        {
            NewMessage = new Message();
            Conversations = new List<Conversation>();
            Conversations = DummyConversations.GetConversations();
        }

        private void CollapseMessage(Message message)
        {
            message.Selected = !message.Selected;
            message.ReadStatus = true;
        }

        private string SwitchMessageBackGround(Message message)
        {
            if (message.Selected == true)
            {
                return "#E8F5E9";
            }
            else if (message.Selected == false && message.ReadStatus == false)
            {
                return "#E8F5E9;border-width:thick;";
            }
            else
            {
                return "#FFFFFF";
            }
        }

        private void CollapseConversation(Conversation conversation)
        {
            conversation.Selected = !conversation.Selected;
        }


        private string SwitchConversationBackGround(bool selected)
        {
            if (selected == true)
            {
                return "#E8F5E9";
            }
            else
            {
                return "#FFFFFF";
            }
        }


        private string GetPendingMessage(Conversation conversation)
        {
            string pendingAnswer = "";
            foreach (var message in conversation.Messages)
            {
                if (message.Status == EMessageStatus.PendingAnswer)
                {
                    pendingAnswer = message.PendingAnswer;
                }
            }
            return pendingAnswer;
        }

        private bool GetImportance(Conversation conversation)
        {
            bool flag = false;
            foreach (var message in conversation.Messages)
            {
                if (message.Importance == true)
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
                if(message.ReadStatus == false)
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
            NewMessage.Files = new List<IBrowserFile>();
            NewMessage.Files.Add(NewMessage.NewFile);
        }


        private void AddNewMessage(Conversation conversation)
        {
            NewMessage.CreationDate = DateTime.Now.ToString("dd/MM/yyyy");
            NewMessage.ReceptionDate = DateTime.Now.ToString("dd/MM/yyyy");
            NewMessage.SendingDate = DateTime.Now.ToString("dd/MM/yyyy");
            DummyConversations.AddNewMessage(conversation, NewMessage);
            conversation.NewMessage = false;           
            Conversations = new List<Conversation>();
            Conversations = DummyConversations.GetConversations();
            NewMessage = new Message();
        }

        private void SetImportance()
        {
            NewMessage.Importance = true;
            
        }

        private Color SetImportanceColor(Color color)
        {
            if (NewMessage.Importance == true)
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
            if (NewMessage.Files != null && NewMessage.Files.Count>0)
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
}
