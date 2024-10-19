using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class UserFriend : IEntity
    {
        public string? Id { get; set; }
        public string? FriendshipId { get; set; }
        public string? UserId { get; set; }
        public string? FriendId { get; set; }
        public virtual User? Friend { get; set; }
    }
}
