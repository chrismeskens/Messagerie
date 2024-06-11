using Essai1.Domain;
using Essai1.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Essai1.Pages;

public partial class Collapsing
{
    private List<Conversation>? Conversations { get; set; }

    private bool CreateNewMessage { get; set; }
    private Message NewMessage { get; set; } = new();

    [Inject]
    public required IConversationsService ConversationsService { get; set; }

    protected override void OnInitialized()
    {
        Conversations = ConversationsService.GetConversations();
    }

    private string SwitchConversationBackGround(bool selected)
    {
        return selected
            ? "#E8F5E9"
            : "#FFFFFF";
    }

    private void CreateMessage(Conversation conversation)
    {
        NewMessage = conversation.CreateMessage();
    }


}