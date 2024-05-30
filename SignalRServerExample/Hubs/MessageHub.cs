using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groupNames)
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Caller
            // Only who send data to server with this client
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            // All of clients
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            // All of clients except self
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Methods
            #region AllExcept
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            //await Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessage", message);  
            #endregion
            #region Clients
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region Group Except
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Groups
            //await Clients.Groups(groupNames).SendAsync("receiveMessage", message);
            #endregion
            #region OtherInGroups
            //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region User
            //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion
            #region OtherInGroups
            //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion
            #endregion
        }

        public override async Task OnConnectedAsync()
        {
           await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addgroup(string connectionId, string groupName) 
        { 
            Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
