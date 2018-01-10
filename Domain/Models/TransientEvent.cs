using System;
using Newtonsoft.Json;

namespace TransientEventDisplay.Domain.Models
{
    public class TransientEvent
    {
        public DateTime Timestamp { get; set; }
        
        public string EventType { get; set; }
        
        public string Category { get; set; }
        
        public string Data { get; set; }
        
        public string ChannelId { get; set; }
    }
}