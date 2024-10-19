using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class Post : IEntity
    {
        public string? Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? UserId { get; set; }
        public string? Text { get; set; }
        public DateTime PostShareTime { get; set; }
        public virtual User? User { get; set; }
    }
}
