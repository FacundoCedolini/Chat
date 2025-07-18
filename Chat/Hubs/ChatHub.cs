﻿// Hubs/ChatHub.cs
using Chat.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Chat.Models;
using Message = Chat.Models.Message;

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

            // Guardar mensaje
            using (var db = new AppDbContext())
            {
                var msg = new Message
                {
                    FromUsername = fromUser,
                    ToUsername = string.IsNullOrWhiteSpace(toUser) ? null : toUser,
                    Content = message,
                    Timestamp = DateTime.Now
                };

                db.Messages.Add(msg);
                await db.SaveChangesAsync();
            }

            if (string.IsNullOrWhiteSpace(toUser))
            {
                // Mensaje general
                await Clients.AllExcept(Context.ConnectionId)
                    .SendAsync("ReceiveMessage", fromUser, "", message);

                await Clients.Caller.SendAsync("ReceiveMessage", fromUser, "", message);
            }
            else if (ConnectedUsers.Users.TryGetValue(toUser, out var targetConnectionId))
            {
                // Mensaje privado
                await Clients.Client(targetConnectionId)
                    .SendAsync("ReceiveMessage", fromUser, toUser, message);

                await Clients.Caller.SendAsync("ReceiveMessage", fromUser, toUser, message);
            }
        }

        public async Task SendGroupMessage(int groupId, string message)
        {
            var fromUser = ConnectedUsers.Users
                .FirstOrDefault(kvp => kvp.Value == Context.ConnectionId).Key;

            if (string.IsNullOrEmpty(fromUser))
                return;

            using (var db = new AppDbContext())
            {
                var msg = new Message
                {
                    FromUsername = fromUser,
                    GroupId = groupId,
                    Content = message,
                    Timestamp = DateTime.Now
                };
                db.Messages.Add(msg);
                await db.SaveChangesAsync();
            }

            using (var db = new AppDbContext())
            {
                var miembros = db.UserGroups
                    .Where(ug => ug.GroupId == groupId)
                    .Select(ug => ug.User.Username)
                    .ToList();

                foreach (var miembro in miembros)
                {
                    if (ConnectedUsers.Users.TryGetValue(miembro, out var connId))
                    {
                        await Clients.Client(connId).SendAsync("ReceiveGroupMessage", fromUser, groupId, message);
                    }
                }
            }
        }


        public override async Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext()?.Request.Query["username"].ToString();

            if (!string.IsNullOrEmpty(username))
            {
                ConnectedUsers.Users[username] = Context.ConnectionId;
                await NotifyUsersChanged();
            }

            await base.OnConnectedAsync();

            var users = ConnectedUsers.Users.Keys.ToList();
            await Clients.Caller.SendAsync("UsersUpdated", users);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var username = Context.GetHttpContext()?.Request.Query["username"].ToString();

            if (!string.IsNullOrEmpty(username))
            {
                ConnectedUsers.Users.TryRemove(username, out _);
                await NotifyUsersChanged();
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task NotifyGroupCreated(int groupId, List<string> usernames)
        {
            foreach (var username in usernames)
            {
                if (ConnectedUsers.Users.TryGetValue(username, out var connId))
                {
                    await Clients.Client(connId).SendAsync("GroupCreated", groupId);
                }
            }
        }

        public async Task<List<Message>> GetMessageHistory(string? withUser = null)
        {
            try
            {
                var currentUser = Context.GetHttpContext()?.Request.Query["username"].ToString();
                if (string.IsNullOrEmpty(currentUser))
                    return new List<Message>();

                using var db = new AppDbContext();

                var currentEntry = ConnectedUsers.Users
                    .FirstOrDefault(kvp => kvp.Value == Context.ConnectionId);

                if (string.IsNullOrEmpty(currentEntry.Key))
                {
                    Console.WriteLine("No se encontró el usuario conectado.");
                    return new List<Message>();
                }

                if (string.IsNullOrWhiteSpace(withUser))
                {
                    return await db.Messages
                        .Where(m => m.ToUsername == null && m.GroupId == null)
                        .OrderBy(m => m.Timestamp)
                        .ToListAsync();
                }
                else
                {
                    return await db.Messages
                        .Where(m =>
                            (m.FromUsername == currentUser && m.ToUsername == withUser) ||
                            (m.FromUsername == withUser && m.ToUsername == currentUser))
                        .OrderBy(m => m.Timestamp)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GetMessageHistory: " + ex.Message);
                return new List<Message>();
            }
        }

        public async Task<List<Message>> GetGroupMessageHistory(int groupId)
        {
            using var db = new AppDbContext();
            return await db.Messages
                .Where(m => m.GroupId == groupId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }


        public Task<List<string>> GetConnectedUsers()
        {
            return Task.FromResult(ConnectedUsers.Users.Keys.ToList());
        }

        private async Task NotifyUsersChanged()
        {
            var users = ConnectedUsers.Users.Keys.ToList();
            await Clients.All.SendAsync("UsersUpdated", users);
        }

    }
}