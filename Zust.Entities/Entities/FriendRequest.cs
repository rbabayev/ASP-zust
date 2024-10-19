using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class FriendRequest : IEntity
    {
        public string? Id { get; set; }
        public string? SenderId { get; set; }
        public string? Content { get; set; }
        public string? Status { get; set; }
        public string? ReceiverId { get; set; }
        public virtual User? Sender { get; set; }
        public DateTime RequestTime { get; set; }
        public bool Response { get; set; }

    }
}
