using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class Message : IEntity
    {
        public string? Id { get; set; }
        public string? SenderId { get; set; }
        public string? ChatId { get; set; }
        public string? ReceiverId { get; set; }
        public string? Text { get; set; }
        public bool IsSeen { get; set; }
        public DateTime SentTime { get; set; }

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
    }



}
