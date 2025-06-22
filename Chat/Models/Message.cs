// Models/Message.cs
using System;

namespace Chat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string FromUsername { get; set; } = string.Empty;
        public string? ToUsername { get; set; } // null = mensaje público
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

}
