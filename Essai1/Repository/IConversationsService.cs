using Essai1.Domain;

namespace Essai1.Repository;

/// <summary>
/// Interface for the conversations service
/// </summary>
public interface IConversationsService
{
    /// <summary>
    /// Get all conversations
    /// </summary>
    /// <returns>Returns a list of conversations</returns>
    List<Conversation> GetConversations();
    
    /// <summary>
    /// Get all messages from a conversation
    /// </summary>
    /// <param name="conversation">The conversation</param>
    /// <param name="message">The message</param>
    void AddNewMessage(Conversation conversation, Message message);
}