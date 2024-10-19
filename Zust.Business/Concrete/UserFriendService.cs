using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class UserFriendService : IUserFriendService
    {
        private readonly IUserFriendDal _userFriendDal;
        private readonly IUserService _userService;
        public UserFriendService(IUserFriendDal userFriendDal, IUserService userService)
        {
            _userFriendDal = userFriendDal;
            _userService = userService;
        }

        public async Task AddFriendship(UserFriend friendship)
        {
            await _userFriendDal.AddAsync(friendship);
        }

        public async Task<IEnumerable<User?>> GetAllFollowers(string userId)
        {
            var friendships = await _userFriendDal.GetAllAsync();

            var followerId = friendships.Where(f => f.FriendId == userId && !string.IsNullOrEmpty(f.UserId))
                                        .Select(f => f.UserId)
                                        .ToList();

            var follower = await Task.WhenAll(followerId.Select(id =>
                string.IsNullOrEmpty(id) ? Task.FromResult<User?>(null) : _userService.GetUserById(id)));

            return follower;
        }

        public async Task<IEnumerable<User?>> GetAllFollowing(string userId)
        {
            var friendships = await _userFriendDal.GetAllAsync();

            var followingId = friendships.Where(f => f.UserId == userId && !string.IsNullOrEmpty(f.FriendId))
                                         .Select(f => f.FriendId)
                                         .ToList();

            var following = await Task.WhenAll(followingId.Select(id =>
                string.IsNullOrEmpty(id) ? Task.FromResult<User?>(null) : _userService.GetUserById(id)));

            return following;
        }



    }
}
