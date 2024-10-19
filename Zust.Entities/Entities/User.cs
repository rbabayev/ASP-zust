using Microsoft.AspNetCore.Identity;
using Zust.Core.Abstract;


namespace Zust.Entities.Entities
{
    public class User : IdentityUser, IEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsOnline { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DisConnectTime { get; set; } = DateTime.Now;
        public string? ConnectTime { get; set; } = "";
        public string? PhoneNum { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? BackgroundImageUrl { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; } = new List<Message>();

        public virtual ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
    }
}
