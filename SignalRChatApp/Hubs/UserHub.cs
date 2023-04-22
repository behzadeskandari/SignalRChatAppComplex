using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApp.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;
        public static int TotalUsers { get; set; } = 0;

        public override  async Task OnConnectedAsync()
        {
            TotalUsers++;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {

            TotalUsers--;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            await base.OnDisconnectedAsync(exception);
        }
        public async Task<string> NewWindowLoaded(string name)
        {
            TotalViews++;
            //send update to all clients that toal views have been updated

            await Clients.All.SendAsync("updateTotalViews", TotalViews);
            return $"total Views {name}-{TotalViews}";

        }


    }
}
