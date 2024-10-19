using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class Comment : IEntity
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? PostId { get; set; }
        public string? Text { get; set; }
        public DateTime CommentTime { get; set; }
        public virtual User? User { get; set; }
        public virtual Post? Post { get; set; }

    }
}
