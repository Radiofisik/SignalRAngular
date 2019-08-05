using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace backend.Hubs
{
    public class MessageHub: Hub
    {
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }

        public async Task Subscribe(string scope)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, scope);
        }

        public async Task Unsubscribe(string scope)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, scope);
        }
    }
}
