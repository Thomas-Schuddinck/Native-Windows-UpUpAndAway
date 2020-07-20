using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string group, string name, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", name, message);
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
