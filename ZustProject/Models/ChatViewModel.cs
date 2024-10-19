﻿using Zust.Entities.Entities;

namespace ZustProject.Models
{
    public class ChatViewModel
    {
        public string? CurrentUserId { get; set; }
        public Chat? CurrentChat { get; set; }
        public IEnumerable<Chat>? Chats { get; set; }
        public string? CurrentReceiver { get; internal set; }

    }
}
