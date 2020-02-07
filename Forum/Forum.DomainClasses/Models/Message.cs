using System;

namespace Forum.DomainClasses.Models
{
    public class Message
    {
        public string MessageID { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverUsername { get; set; }
        public string SenderID { get; set; }
        public string SenderUsername { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual User User { get; set; }
    }
}
