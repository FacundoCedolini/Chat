// ConnectedUsers.cs
using System.Collections.Concurrent;

namespace Chat.Data
{
    public static class ConnectedUsers
    {
        // username -> connectionId
        public static ConcurrentDictionary<string, string> Users = new();
    }
}
