using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface IFriendRequestService
    {
        Task AddFriend(FriendRequest friendRequest);
        Task<IEnumerable<FriendRequest>> GetAllRequest(string requestId);
        Task DeclineRequest(FriendRequest friend);

    }
}
