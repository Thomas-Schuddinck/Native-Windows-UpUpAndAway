using API.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public async Task SendMessage(string group, string name, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", name, message);
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task SendWarningToPassenger(string passenger, string message)
        {
            var conn = _connections.GetConnections(passenger);
            await Clients.Client(conn.FirstOrDefault()).SendAsync("ReceiveWarning", message);
        }

        public async Task SendWarning(string message)
        {
            await Clients.Clients(_connections.GetPassengerConnections().ToList()).SendAsync("ReceiveWarning", message);
        }

        public async Task GetPassengers()
        {
            var hulp = _connections.GetPassengers();
            await Clients.Caller.SendAsync("SendPassengers", _connections.GetPassengers());
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var queryStr = httpContext.Request.Query["name"];
            if (queryStr.Count != 0)
                _connections.Add(queryStr.First(), Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            var queryStr = httpContext.Request.Query["name"];
            if (queryStr.Count != 0)
                _connections.GetConnections(queryStr.First()).ToList().ForEach(i => _connections.Remove(queryStr.First(),i));
            return base.OnDisconnectedAsync(exception);
        }
    }
}
