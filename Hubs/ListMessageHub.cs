namespace TransientEventDisplay.Hubs
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    using TransientEventDisplay.Domain.Models;

    public class ListMessageHub : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.InvokeAsync("Send", message);
        }
        
        public Task TransmitEvent(TransientEvent evt)
        {
            return Clients.Group(evt.ChannelId).InvokeAsync("EventPublished", evt.Category, evt.EventType, evt.Data);
        }

        public void JoinChannel(string channelId)
        {
            this.Groups.AddAsync(this.Context.ConnectionId, channelId);
        }

        public Task LeaveChannel(string channelId)
        {
            return Groups.RemoveAsync(Context.ConnectionId, channelId);
        }
    }
}