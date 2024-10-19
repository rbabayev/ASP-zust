using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface IMessageService
    {
        Task AddMessage(Message message);
        Task<IEnumerable<Message>> GetAllChatMessages(string chatId);

    }
}
