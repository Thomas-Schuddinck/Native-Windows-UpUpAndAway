﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string firstname, string lastname, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", firstname, lastname, message);
        }
    }
}
