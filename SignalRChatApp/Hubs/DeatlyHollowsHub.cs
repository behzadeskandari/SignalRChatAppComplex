using Microsoft.AspNetCore.SignalR;

namespace SignalRChatApp.Hubs
{
    public class DeatlyHollowsHub : Hub
    {
        public Dictionary<string,int> GetRaceStatus()
        {
            return SD.DealthyHallowRace;
        }

    }
}
