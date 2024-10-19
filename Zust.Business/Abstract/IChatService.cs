using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface IChatService
    {
        Task AddChat(Chat chat);
        Task<Chat?> GetChat(string senderId, string receiverId);
        Task<IEnumerable<Chat>> GetAllChats(string userId);
        Task<Chat?> GetChatById(string chatId);
    }
}
