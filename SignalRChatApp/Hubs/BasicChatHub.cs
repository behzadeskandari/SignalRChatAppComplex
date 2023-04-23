﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRChatApp.Data;

namespace SignalRChatApp.Hubs
{
    public class BasicChatHub : Hub
    {
        private readonly ApplicationDbContext _db;
        public BasicChatHub(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SendMessageToAll(string user, string message)
        {
            Console.WriteLine(user);
            Console.WriteLine(message);
            await Clients.All.SendAsync("MessageReceived", user, message);
        }

        [Authorize]
        public async Task SendMessageToReceiver(string sender, string receiver, string message)
        {
            var userId = _db.Users.FirstOrDefault(u => u.Email.ToLower() == receiver.ToLower()).Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageReceived", sender, message);
            }

        }

    }
}
