using Microsoft.AspNetCore.SignalR;
using System.Linq;

namespace SignalRChatApp.Hubs
{
    public class NotificationHub : Hub
    {
        public static int NotificationCounter = 0;
        public static List<string> messages = new List<string>();

        public async Task SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                NotificationCounter++;
                messages.Add(message);
                await LoadMessage();
            }
        }
        
        public async Task LoadMessage()
        {
            await Clients.All.SendAsync("LoadNotification", messages, NotificationCounter);
        }
    }
}
