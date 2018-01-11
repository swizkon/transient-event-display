using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Features;
using TransientEventDisplay.Hubs;
using TransientEventDisplay.Domain.Models;
using TransientEventDisplay.Domain.Commands;
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;

namespace TransientEventDisplay.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IHubContext<EventsMessageHub> _hubContext;

        public EventsController(IHubContext<EventsMessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public PushEventCommand Post([FromBody] PushEventCommand data)
        {
            _hubContext
            .Clients
            .Group(data.ChannelId)
            .InvokeAsync("EventPublished", data.Category, data.EventType, data.Data);

            return data;
        }
    }
}
