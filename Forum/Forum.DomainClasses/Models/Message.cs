using System;

namespace Forum.DomainClasses.Models
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }
        public string SenderUsername { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }

        public virtual User User { get; set; }
    }
}
