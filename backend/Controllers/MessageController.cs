using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace backend.Controllers
{
    [Route("api/message")]
    public class MessageController: Controller
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _hubContext.Clients.All.SendCoreAsync("send", new[] {"hello from server"});
            return Ok();
        }

        [HttpPost("sendToGroup")]
        public IActionResult SendToGroup()
        {
            _hubContext.Clients.Group("groupName").SendCoreAsync("method", new[] { "hello from server to group" });
            return Ok();
        }

        [HttpPost("sendToGroup2")]
        public IActionResult SendToGroup2()
        {
            _hubContext.Clients.Group("groupName2").SendCoreAsync("method", new[] { "hello from server to group" });
            return Ok();
        }
    }
}
