using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {
        static List<string> clients = new List<string>();
        
        public override async Task OnConnectedAsync()
        {
            var id = Context.ConnectionId;
            clients.Add(id);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", id);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(id);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var id = Context.ConnectionId;
            clients.Remove(id);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeaved", id);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(id);
        }
    }
}
