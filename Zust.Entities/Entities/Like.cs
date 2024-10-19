using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class Like : IEntity
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? PostId { get; set; }
        public virtual User? User { get; set; }
        public virtual Post? Post { get; set; }

    }
}
