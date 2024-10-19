using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IFriendRequestDal _friendRequestDal;

        public FriendRequestService(IFriendRequestDal friendRequestDal)
        {
            _friendRequestDal = friendRequestDal;
        }

        public async Task AddFriend(FriendRequest friendRequest)
        {
            await _friendRequestDal.AddAsync(friendRequest);
        }

        public async Task DeclineRequest(FriendRequest friend)
        {
            await _friendRequestDal.DeleteAsync(friend);
        }

        public async Task<IEnumerable<FriendRequest>> GetAllRequest(string requestId)
        {
            return await _friendRequestDal.GetAllAsync(f => f.Id == requestId);
        }
    }
}
