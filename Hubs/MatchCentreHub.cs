using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRLiveMatchProject.Hubs
{
public class MatchCentreHub : Hub
    {
        public async Task SendMatchCentreUpdate()
        {
            await Clients.All.SendAsync("RefreshMatchCentre");
        }
    }
}
