// Models/Message.cs
using System;

namespace Chat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string FromUsername { get; set; } = string.Empty;
        public string? ToUsername { get; set; } // null = mensaje público o de grupo 
        public int? GroupId { get; set; } //null = no es de grupo
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

}
