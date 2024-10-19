using Zust.Core.Abstract;

namespace Zust.Entities.Entities
{
    public class Chat : IEntity
    {
        public string? Id { get; set; }
        public string? SenderUserId { get; set; }
        public string? ReceiverUserId { get; set; }
        public string? MessageTxt { get; set; }
        public bool IsSeen { get; set; }
        public DateTime MessageTime { get; set; }

        public virtual User? ReceiverUser { get; set; }

        public virtual IEnumerable<Message>? Messages { get; set; }
        public Chat()
        {
            Messages = new List<Message>();
        }
    }


}
