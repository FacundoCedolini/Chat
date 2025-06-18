// Hubs/ChatHub.cs
using Chat.Data;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string toUser, string message)
        {
            var fromUser = ConnectedUsers.Users
                .FirstOrDefault(kvp => kvp.Value == Context.ConnectionId).Key;

            if (string.IsNullOrEmpty(fromUser))
                return;

            if (string.IsNullOrWhiteSpace(toUser))
            {
                // Enviar a todos menos al emisor
                await Clients.AllExcept(Context.ConnectionId)
                    .SendAsync("ReceiveMessage", fromUser, message);

                // Mostrar al emisor su propio mensaje
                await Clients.Caller.SendAsync("ReceiveMessage", fromUser, message);
            }
            else if (ConnectedUsers.Users.TryGetValue(toUser, out var targetConnectionId))
            {
                // Enviar mensaje al destinatario
                await Clients.Client(targetConnectionId)
                    .SendAsync("ReceiveMessage", fromUser, message);

                // Mostrar también al emisor
                await Clients.Caller.SendAsync("ReceiveMessage", fromUser, message);
            }
        }


        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var username = httpContext?.Request.Query["username"].ToString();

            if (!string.IsNullOrEmpty(username))
            {
                ConnectedUsers.Users[username] = Context.ConnectionId;
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userToRemove = ConnectedUsers.Users
                .FirstOrDefault(kvp => kvp.Value == Context.ConnectionId).Key;

            if (!string.IsNullOrEmpty(userToRemove))
            {
                ConnectedUsers.Users.TryRemove(userToRemove, out _);
            }

            return base.OnDisconnectedAsync(exception);
        }

    }
}
