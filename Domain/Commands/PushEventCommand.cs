namespace TransientEventDisplay.Domain.Commands
{
    public class PushEventCommand
    {
        public string ChannelId { get; set; }

        public string EventType { get; set; }
        
        public string Category { get; set; }
        
        public string Data { get; set; }
    }
}