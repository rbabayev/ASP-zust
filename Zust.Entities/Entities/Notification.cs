using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class Notification : IEntity
    {
        public string? Id { get; set; }
        public DateTime SendTime { get; set; }
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }

    }
}
