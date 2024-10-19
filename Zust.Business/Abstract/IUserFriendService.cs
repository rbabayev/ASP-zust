using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface IUserFriendService
    {
        Task AddFriendship(UserFriend friendship);
        Task<IEnumerable<User?>> GetAllFollowers(string userId);
        Task<IEnumerable<User?>> GetAllFollowing(string userId);

    }
}
