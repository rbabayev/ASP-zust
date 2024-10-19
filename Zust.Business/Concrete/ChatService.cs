using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class ChatService : IChatService
    {
        private readonly IChatDal _chatDal;

        public ChatService(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }
        public async Task AddChat(Chat chat)
        {
            await _chatDal.AddAsync(chat);
        }

        public async Task<IEnumerable<Chat>> GetAllChats(string userId)
        {
            var chat = await _chatDal.GetAllAsync(chat => chat.SenderUserId == userId || chat.ReceiverUserId == userId);
            return chat;

        }

        public async Task<Chat?> GetChat(string senderId, string receiverId)
        {
            return await _chatDal.GetAsync(chat => chat.SenderUserId == senderId && chat.ReceiverUserId == receiverId);
        }

        public async Task<Chat?> GetChatById(string chatId)
        {
            return await _chatDal.GetAsync(chat => chat.Id == chatId);
        }
    }
}
