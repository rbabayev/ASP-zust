using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zust.Entities.Entities;

namespace Zust.DataAccess.Data
{
    public partial class ZustDbContext : IdentityDbContext
    {

        public ZustDbContext(DbContextOptions<ZustDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Chat>? Chats { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }
        public virtual DbSet<FriendRequest>? FriendRequests { get; set; }
        public virtual DbSet<Message>? Messages { get; set; }
        public virtual DbSet<Post>? Posts { get; set; }
        public virtual DbSet<UserFriend>? UserFriends { get; set; }
        public virtual DbSet<Like>? Likes { get; set; }
        public virtual DbSet<Notification>? Notifications { get; set; }

    }
}
